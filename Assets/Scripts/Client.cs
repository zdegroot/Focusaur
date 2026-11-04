using System;
using System.IO;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using UnityEngine;
using TMPro; // Make sure you have TextMeshPro imported

public class PythonTcpClient : MonoBehaviour
{
    [Header("UI References")]
    [SerializeField] private TMP_InputField ipInputField; // Drag your InputField here in Unity
    [SerializeField] private string defaultIp = "127.0.0.1";

    private TcpClient socketConnection;
    private Thread clientReceiveThread;
    private NetworkStream stream;
    private bool isConnected = false;

    void Start()
    {
        // Optional: Set default text in the input field if it's assigned
        if (ipInputField != null)
        {
            ipInputField.text = defaultIp;
        }
    }

    // Call this method when the user clicks the "Connect" button
    public void ConnectWithUserIp()
    {
        string targetIp = defaultIp;

        if (ipInputField != null && !string.IsNullOrEmpty(ipInputField.text))
        {
            targetIp = ipInputField.text.Trim();
        }

        ConnectToTcpServer(targetIp);
    }

    private void ConnectToTcpServer(string serverIp)
    {
        try
        {
            Debug.Log($"Attempting to connect to {serverIp}:5000...");
            
            // Pass the IP into a parameterized thread start or lambda
            clientReceiveThread = new Thread(() => ListenForData(serverIp));
            clientReceiveThread.IsBackground = true;
            clientReceiveThread.Start();
        }
        catch (Exception e)
        {
            Debug.Log("On client connect exception: " + e);
        }
    }

    private void ListenForData(string serverIp)
    {
        try
        {
            socketConnection = new TcpClient(serverIp, 5000);
            stream = socketConnection.GetStream();
            isConnected = true;
            Debug.Log($"Connected successfully to Python Server at {serverIp}!");

            byte[] bytes = new byte[1024];
            while (isConnected)
            {
                int length = stream.Read(bytes, 0, bytes.Length);
                if (length == 0) break;

                var incomingData = new byte[length];
                Array.Copy(bytes, 0, incomingData, 0, length);
                
                string serverMessage = Encoding.UTF8.GetString(incomingData);
                Debug.Log("Server says: " + serverMessage);
            }
        }
        catch (Exception socketException)
        {
            Debug.Log("Socket exception: " + socketException);
            isConnected = false;
        }
    }

    public void SendMessageToPython(string message)
    {
        if (!isConnected || socketConnection == null || stream == null)
        {
            Debug.LogWarning("Cannot send message: Not connected to server.");
            return;
        }

        try
        {
            byte[] clientMessageAsByteArray = Encoding.UTF8.GetBytes(message + "\n");
            stream.Write(clientMessageAsByteArray, 0, clientMessageAsByteArray.Length);
            Debug.Log("Sent to Python: " + message);
        }
        catch (Exception socketException)
        {
            Debug.Log("Error sending to socket: " + socketException);
        }
    }

    void OnApplicationQuit()
    {
        isConnected = false;
        stream?.Close();
        socketConnection?.Close();
        if (clientReceiveThread != null && clientReceiveThread.IsAlive)
        {
            clientReceiveThread.Join(100); // Wait briefly for thread to close safely
        }
    }
}
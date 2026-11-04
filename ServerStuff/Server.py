import socket

# Configuration
HOST = "127.0.0.1"
PORT = 5000


def run_server():
    server_socket = socket.socket(socket.AF_INET, socket.SOCK_STREAM)
    # Reuse address to avoid "Address already in use" errors on restart
    server_socket.setsockopt(socket.SOL_SOCKET, socket.SO_REUSEADDR, 1)
    server_socket.bind((HOST, PORT))
    server_socket.listen(1)

    print(f"Python TCP Server listening on {HOST}:{PORT}...")

    while True:
        conn, addr = server_socket.accept()
        print(f"Connected by client: {addr}")

        try:
            while True:
                # Receive data from Unity (blocking until data arrives)
                data = conn.recv(1024)
                if not data:
                    break  # Client disconnected

                message = data.decode("utf-8").strip()
                print(f"Received from Unity: {message}")

                # Send a response back to Unity
                response = f"Acknowledged: {message}\n"
                conn.sendall(response.encode("utf-8"))

        except ConnectionResetError:
            print("Connection was forcibly closed by the client.")
        finally:
            conn.close()
            print("Connection closed. Waiting for new connection...\n")


if __name__ == "__main__":
    run_server()
using System.Collections.Generic;
using UnityEngine;

public class PlayerStuff : MonoBehaviour
{
    public static int Leaves = 0;
    public static int Energy = 0;
    public static int QuestsCompleted = 0;
    public static Dictionary<string,int> Inventory = new Dictionary<string, int>();
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Leaves = 0;
        Energy = 0;
		QuestsCompleted = 0;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

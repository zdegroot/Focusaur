using System.Collections.Generic;
using UnityEngine;

public class PlayerVariables : MonoBehaviour
{
    public int Leaves = 0;
    public int Energy = 0;
    public int QuestsCompleted = 0;

    public Dictionary<string, int> Inventory = new Dictionary<string, int>();

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

    public int getLeaves()
    {
        return Leaves;
    }

    public void addLeaves(int numLeaves)
    {
        Leaves = Leaves + numLeaves;
    }

    public void removeLeaves(int numLeaves)
    {
        if (numLeaves < Leaves)
        {
            Leaves = Leaves - numLeaves;
        }
    }

    public int getEnergy()
    {
        return Energy;
    }

    public int getQuestsCompleted()
    {
        return QuestsCompleted;
    }

    public void questCompleted()
    {
        QuestsCompleted++;
    }

    public void questRecinded()
    {
        QuestsCompleted--;
    }
    
}

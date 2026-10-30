using System.Collections.Generic;
using UnityEngine;

public class PlayerVariables : MonoBehaviour
{
    public int Leaves = 0;
    public int Energy = 0;
    public int QuestsCompleted = 0;


    public List<CosmeticItem> Inventory = new List<CosmeticItem>();

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Leaves = 0;
        Energy = 0;
        QuestsCompleted = 0;
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
        if (numLeaves <= Leaves)
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

    public void AddToInventory(CosmeticItem tempItem)
    {
        Inventory.Add(tempItem);
    }

    public void readInventory()
    {
        for (int i = 0; i < Inventory.Count; i++)
        {
            Debug.Log(Inventory[i].getName() + " : " + Inventory[i].getPrice() + " : " + Inventory[i].isBought());
        }
    }
    
}

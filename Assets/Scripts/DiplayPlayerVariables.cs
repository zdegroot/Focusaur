using UnityEngine;
using TMPro;
public class DiplayPlayerVariables : MonoBehaviour
{
    public PlayerVariables Player;
    public TMP_Text Leaves;
    public TMP_Text Quests;
    public TMP_Text Energy;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Leaves.text = "Leaves: " + Player.getLeaves();
        Quests.text = "Quests Completed: " + Player.getQuestsCompleted();
        Energy.text = "Energy: " + Player.getEnergy();
    }
}

using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class BuyingItems : MonoBehaviour
{
    //private int[] buttons = new int[6];
    //private bool[] buttonPressed = new bool[6];
    public PlayerVariables Player;
    public Button[] buttonsUI = new Button[6];
    public CosmeticScript cosmeticScript;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        for (int i = 0; i < buttonsUI.Length; i++)
        {
            int slot = i;
            buttonsUI[i].onClick.AddListener(() => turnButtonOn(slot));
        }

        // buttons[0] = 0;
        // buttons[1] = 0;
        // buttons[2] = 0;
        // buttons[3] = 0;
        // buttons[4] = 0;
        // buttons[5] = 0;
        // buttonPressed[0] = false;
        // buttonPressed[1] = false;
        // buttonPressed[2] = false;
        // buttonPressed[3] = false;
        // buttonPressed[4] = false;
        // buttonPressed[5] = false;
    }
    //
    // // Update is called once per frame
    // void Update()
    // {
    //     if (buttons[0] == 1 && buttonPressed[0] == false)
    //     {
    //         if (Player.getLeaves() >= cosmeticScript.GetItemInSlot(0).getPrice())
    //         {
    //             ModButton(0);
    //
    //         }
    //
    //         buttonPressed[0] = true;
    //     }
    //     if (buttons[1] == 1  && buttonPressed[1] == false)
    //     {
    //         if (Player.getLeaves() >= cosmeticScript.GetItemInSlot(1).getPrice())
    //         {
    //             ModButton(1);
    //         }
    //         buttonPressed[1] = true;
    //     }
    //     if (buttons[2] == 1  && buttonPressed[2] == false)
    //     {
    //         if (Player.getLeaves() >= cosmeticScript.GetItemInSlot(2).getPrice())
    //         {
    //             ModButton(2);
    //
    //         }
    //         buttonPressed[2] = true;
    //     }
    //     if (buttons[3] == 1  && buttonPressed[3] == false)
    //     {
    //         if (Player.getLeaves() >= cosmeticScript.GetItemInSlot(3).getPrice())
    //         {
    //             ModButton(3);
    //
    //         }
    //         buttonPressed[3] = true;
    //     }
    //     if (buttons[4] == 1  && buttonPressed[4] == false)
    //     {
    //         if (Player.getLeaves() >= cosmeticScript.GetItemInSlot(4).getPrice())
    //         {
    //             ModButton(4);
    //         }
    //         buttonPressed[4] = true;
    //     }
    //     if (buttons[5] == 1  && buttonPressed[5] == false)
    //     {
    //         if (Player.getLeaves() >= cosmeticScript.GetItemInSlot(5).getPrice())
    //         {
    //             ModButton(5);
    //         }
    //         buttonPressed[5] = true;
    //     }
    // }


    public void turnButtonOn(int index)
    {
        if (cosmeticScript.TryBuySlot(index))
        {
            ModButton(index);
        }
    }
            

    public void ModButton(int index)
    {
        TMP_Text label = buttonsUI[index].GetComponentInChildren<TMP_Text>();
        label.text = "Collected";
        buttonsUI[index].image.color = Color.red;
    }

}

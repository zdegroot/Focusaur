using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class BuyingItems : MonoBehaviour
{
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


    }
 
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

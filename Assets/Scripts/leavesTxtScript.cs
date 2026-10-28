using UnityEngine;
using TMPro;
public class leavesTxtScript : MonoBehaviour
{
    public TMP_Text CosmeticText;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        CosmeticText.text = "Leaves: " + PlayerStuff.Leaves;
    }
}

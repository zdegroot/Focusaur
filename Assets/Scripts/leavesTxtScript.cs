using UnityEngine;
using TMPro;
public class leavesTxtScript : MonoBehaviour
{
    public PlayerVariables Player;
    public TMP_Text CosmeticText;

    // Update is called once per frame
    void Update()
    {
        CosmeticText.text = "Leaves: " + Player.getLeaves();
    }
}

using UnityEngine;

public class NewMonoBehaviourScript : MonoBehaviour
{
    public GameObject[] canvases;

    public void ToggleScreen(int enableIndex)
    {
        for (int i = 0; i < canvases.Length; i++)
        {
            bool isActive = (i == enableIndex);

            CanvasGroup cg = canvases[i].GetComponent<CanvasGroup>();

            if (cg)
            {
                cg.alpha = isActive ? 1 : 0;
                cg.interactable = isActive;
                cg.blocksRaycasts = isActive;
            }
        }
    }
}
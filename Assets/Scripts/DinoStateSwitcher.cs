using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class DinoStateSwitcher : MonoBehaviour
{
    private Image DinoImage;

    private bool isSleepy = false;
    private bool isHappy = true;
    
    public Sprite HappyDino;
    public Sprite SleepyDino;

    void Awake()
    {
        DinoImage = GetComponent<Image>();
    }
    void Start()
    {
        SwapSprite();
    }
    
    void Update()
    {
    }

    private void SwapSprite()
    {
        StartCoroutine(SpriteSwapper());
    }
    
    IEnumerator SpriteSwapper()
    {
        if (isHappy)
        {
            yield return new WaitForSeconds(2f);
            SwapToSleepy();
        }
        else if (isSleepy)
        {
            yield return new WaitForSeconds(2f);
            SwapToHappy();
        }
        
        SwapSprite();
    }

    private void SwapToHappy()
    {
        isSleepy = false;
        isHappy = true;
        DinoImage.sprite = HappyDino;
    }

    private void SwapToSleepy()
    {
        isSleepy = true;
        isHappy = false;
        DinoImage.sprite = SleepyDino;
    }
}

using UnityEngine;

public class GameScroll : MonoBehaviour
{
    public float dragSpeed = 0.01f;

    private Camera cam;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        cam = Camera.main;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.touchCount > 0)
        {
            Touch touch = input.GetTouch(0);
            if (touch.phase == TouchPhase.Moved)
            {
                float moveX = -touch.deltaPosition.x * dragSpeed;
                cam.transform.Translate(moveX, 0, 0, Space.World);
            }
            
        } 
    }
}


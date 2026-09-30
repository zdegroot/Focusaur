using UnityEngine;

public class GameScroll : MonoBehaviour
{
    public float dragSpeed = 0.01f;

    private Camera cam;

    void Start()
    {
        cam = Camera.main;
    }

    void Update()
    {
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);
            if (touch.phase == TouchPhase.Moved)
            {
                float moveX = -touch.deltaPosition.x * dragSpeed;
                cam.transform.Translate(moveX, 0, 0, Space.World);
            }
        }
    }
}

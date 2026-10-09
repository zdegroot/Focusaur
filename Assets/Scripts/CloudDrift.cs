using UnityEngine;

/// <summary>
/// Put on each cloud Image (a child of the "Clouds" container).
/// Anchor the cloud to top-center so Pos X is measured from the middle.
/// </summary>
public class CloudDrift : MonoBehaviour
{
    [Tooltip("Pixels per second. Use a smaller number for 'far away' clouds.")]
    [SerializeField] private float speed = 20f;

    private RectTransform rt;
    private RectTransform parentRect;

    private void Awake()
    {
        rt = (RectTransform)transform;
        parentRect = (RectTransform)transform.parent;
    }

    private void Update()
    {
        Vector2 pos = rt.anchoredPosition;
        pos.x += speed * Time.deltaTime;

        // Distance from the middle at which the cloud is fully off-screen
        float limit = parentRect.rect.width * 0.5f
                      + rt.rect.width * Mathf.Abs(rt.localScale.x) * 0.5f;

        if (speed > 0f && pos.x > limit) pos.x = -limit;
        else if (speed < 0f && pos.x < -limit) pos.x = limit;

        rt.anchoredPosition = pos;
    }
}

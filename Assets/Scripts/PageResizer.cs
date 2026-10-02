using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// Attach to the Panel (the object with the ScrollRect).
/// Resizes every page under Content to match the Panel's size,
/// so each screen fills the display on any phone.
/// </summary>
[RequireComponent(typeof(ScrollRect))]
public class PageSizer : MonoBehaviour
{
    private ScrollRect scrollRect;
    private RectTransform rectTransform;

    private void OnEnable()
    {
        Resize();
    }

    // Called by Unity whenever this RectTransform changes size
    // (screen rotation, different device, window resize, etc.)
    private void OnRectTransformDimensionsChange()
    {
        Resize();
    }

    private void Resize()
    {
        if (scrollRect == null) scrollRect = GetComponent<ScrollRect>();
        if (rectTransform == null) rectTransform = (RectTransform)transform;
        if (scrollRect.content == null) return;

        float width = rectTransform.rect.width;
        float height = rectTransform.rect.height;
        if (width <= 0f || height <= 0f) return;

        foreach (RectTransform page in scrollRect.content)
        {
            page.SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, width);
            page.SetSizeWithCurrentAnchors(RectTransform.Axis.Vertical, height);
        }
    }
}

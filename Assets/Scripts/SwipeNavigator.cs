using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

/// <summary>
/// Attach to the object that has the ScrollRect (your Panel).
/// Snaps to the nearest "page" (screen) after a swipe.
/// Call GoToPage(index) from your bottom buttons.
/// </summary>
[RequireComponent(typeof(ScrollRect))]
public class SwipeNavigator : MonoBehaviour, IBeginDragHandler, IEndDragHandler
{
    [Tooltip("How fast the view slides into place.")]
    [SerializeField] private float snapSpeed = 12f;

    [Tooltip("How far (in fraction of a screen) you must drag to change page.")]
    [SerializeField, Range(0.05f, 0.5f)] private float swipeThreshold = 0.15f;

    private ScrollRect scrollRect;
    private int pageCount;
    private int currentPage;
    private float targetPosition;
    private float dragStartPosition;
    private bool isDragging;

    public int CurrentPage => currentPage;

    private void Awake()
    {
        scrollRect = GetComponent<ScrollRect>();
    }

    private void Start()
    {
        pageCount = scrollRect.content.childCount;
        SnapInstantly(0);
    }

    private void Update()
    {
        if (isDragging || pageCount < 2) return;

        float current = scrollRect.horizontalNormalizedPosition;
        float next = Mathf.Lerp(current, targetPosition, Time.deltaTime * snapSpeed);

        // Stop jittering once we're basically there
        if (Mathf.Abs(next - targetPosition) < 0.0005f) next = targetPosition;

        scrollRect.horizontalNormalizedPosition = next;
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        isDragging = true;
        dragStartPosition = scrollRect.horizontalNormalizedPosition;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        isDragging = false;
        if (pageCount < 2) return;

        // How many pages did the player drag, positive = toward the next page
        float draggedPages = (scrollRect.horizontalNormalizedPosition - dragStartPosition) * (pageCount - 1);

        int newPage = currentPage;
        if (draggedPages > swipeThreshold) newPage++;
        else if (draggedPages < -swipeThreshold) newPage--;

        GoToPage(newPage);
    }

    /// <summary>Slide to a page. Hook this up to your buttons' OnClick.</summary>
    public void GoToPage(int index)
    {
        currentPage = Mathf.Clamp(index, 0, pageCount - 1);
        targetPosition = pageCount > 1 ? (float)currentPage / (pageCount - 1) : 0f;
    }

    private void SnapInstantly(int index)
    {
        GoToPage(index);
        scrollRect.horizontalNormalizedPosition = targetPosition;
    }
}

using UnityEngine;
using UnityEngine.UI;

public class TaskItem : MonoBehaviour
{
    [Header("UI References")]
    public Text titleText;
    public Toggle completionToggle;

    [Header("Task State")]
    public string taskName;
    public bool isCompleted;

    // Called when the task item is instantiated
    public void Initialize(string name)
    {
        taskName = name;
        isCompleted = false;
        UpdateUI();
    }

    // Toggle completed status programmatically or via UI
    public void SetCompleted(bool completed)
    {
        isCompleted = completed;
        UpdateUI();
    }

    private void UpdateUI()
    {
        if (titleText == null) return;

        // Apply Rich Text strikethrough and gray text when completed
        if (isCompleted)
        {
            titleText.text = $"<s>{taskName}</s>";
            titleText.color = Color.gray;
        }
        else
        {
            titleText.text = taskName;
            titleText.color = Color.black;
        }
    }
}
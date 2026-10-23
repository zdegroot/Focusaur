using System;
using UnityEngine;
using UnityEngine.UI;

[System.Serializable]
public struct TaskData
{
    public string taskName;
    public int rewardCurrency; // Amount of currency awarded upon completion
    public bool isCompleted;
}

public class TaskItem : MonoBehaviour
{
    [Header("UI References")]
    [SerializeField] private Text titleText;
    [SerializeField] private Toggle completionToggle;

    [Header("Runtime State")]
    private TaskData currentData;

    public TaskData Data => currentData; // Read-only access to task properties

    public void Initialize(TaskData data)
    {
        currentData = data;
        
        // Display formatted title with currency preview
        titleText.text = $"{currentData.taskName} (+{currentData.rewardCurrency} Gold)";
        titleText.supportRichText = true;

        completionToggle.isOn = currentData.isCompleted;

        completionToggle.onValueChanged.RemoveAllListeners();
        completionToggle.onValueChanged.AddListener(OnToggleChanged);
    }

    private void OnToggleChanged(bool isChecked)
    {
        currentData.isCompleted = isChecked;

        if (isChecked)
        {
            titleText.text = $"<s>{currentData.taskName} (+{currentData.rewardCurrency} Gold)</s>";
            
            // TODO: Call your Currency / Economy Manager here!
        }
        else
        {
            titleText.text = $"{currentData.taskName} (+{currentData.rewardCurrency} Gold)";
            
            // TODO: Deduct currency if unchecked (optional)
        }
    }
}
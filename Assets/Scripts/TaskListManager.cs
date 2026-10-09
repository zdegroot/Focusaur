using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TaskListManager : MonoBehaviour
{
    [Header("UI References")]
    public InputField taskInputField;
    public GameObject taskItemPrefab;
    public Transform taskListContainer;

    [Header("Tracked Objects")]
    public List<TaskItem> activeTasks = new List<TaskItem>();

    public void AddTask()
    {
        Debug.Log("Button was clicked!");
        string text = taskInputField.text.Trim();

        // Don't add blank tasks
        if (string.IsNullOrEmpty(text)) 
            return;

        // Instantiate the Task Prefab into the TaskListContainer
        GameObject go = Instantiate(taskItemPrefab, taskListContainer);
        TaskItem taskObject = go.GetComponent<TaskItem>();

        // Initialize values on the task object
        taskObject.Initialize(text);

        // Bind the UI toggle event directly to the object
        if (taskObject.completionToggle != null)
        {
            taskObject.completionToggle.onValueChanged.AddListener((bool isChecked) => {
                taskObject.SetCompleted(isChecked);
            });
        }

        activeTasks.Add(taskObject);
        taskInputField.text = ""; // Clear input box
    }
}
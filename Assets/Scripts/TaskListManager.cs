using System;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class TaskListManager : MonoBehaviour
{
    [Header("UI References")]
    [SerializeField] private GameObject taskItemPrefab;
    [SerializeField] private Transform taskListContainer;
    [SerializeField] private PlayerVariables Player;
    [Header("Preset Task Data Pool")]
    [SerializeField] private List<TaskData> presetTaskPool = new List<TaskData>
    {
        new TaskData { taskName = "Complete daily review", rewardCurrency = 50, isCompleted = false },
        new TaskData { taskName = "Drink a glass of water", rewardCurrency = 10, isCompleted = false },
        new TaskData { taskName = "Organize workspace", rewardCurrency = 25, isCompleted = false },
        new TaskData { taskName = "Read 10 pages of textbook", rewardCurrency = 40, isCompleted = false },
        new TaskData { taskName = "Stretch for 5 minutes", rewardCurrency = 15, isCompleted = false }
    };

    public void Start()
    {
        AddRandomPresetTask();
        AddRandomPresetTask();
        AddRandomPresetTask();
        AddRandomPresetTask();
        AddRandomPresetTask();
    }


    public void AddRandomPresetTask()
    {
        if (presetTaskPool.Count == 0 || taskItemPrefab == null || taskListContainer == null)
            return;

        int randomIndex = Random.Range(0, presetTaskPool.Count);
        TaskData randomTask = presetTaskPool[randomIndex];

        GameObject newUIItem = Instantiate(taskItemPrefab, taskListContainer);
        TaskItem itemComponent = newUIItem.GetComponent<TaskItem>();
        
        if (itemComponent != null)
        {
            itemComponent.Initialize(randomTask, Player);
        }
    }
}
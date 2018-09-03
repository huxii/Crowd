using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TaskManager
{
    readonly List<Task> taskList = new List<Task>();

    public Task Do(Task task)
    {
        taskList.Add(task);
        task.SetStatus(Task.TaskStatus.PENDING);
        return task;
    }
	
	// Update is called once per frame
	public void Update ()
    {
        for (int i = taskList.Count - 1; i >= 0; --i)
        {
            Task task = taskList[i];

            if (task.IsPending)
            {
                task.SetStatus(Task.TaskStatus.WORKING);
            }

            if (task.IsFinished)
            {
                HandleCompletion(task, i);
            }
            else
            {
                task.Update();
            }
        }
	}

    void HandleCompletion(Task task, int taskIndex)
    {
        if (task.NextTask != null && task.IsSuccessful)
        {
            Do(task.NextTask);
        }

        taskList.RemoveAt(taskIndex);
        task.SetStatus(Task.TaskStatus.DETACHED);
    }
}

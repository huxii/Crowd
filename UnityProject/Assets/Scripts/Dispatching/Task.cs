using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Task
{
    public enum TaskStatus : byte
    {
        DETACHED,
        PENDING,
        WORKING,
        SUCCESS,
        FAIL,
        ABORTED,
    }
    public TaskStatus Status { get; private set; }

    public void SetStatus(TaskStatus newStatus)
    {
        if (Status == newStatus)
        {
            return;
        }

        Status = newStatus;
        switch (newStatus)
        {
            case TaskStatus.WORKING:
                Init();
                break;
            case TaskStatus.SUCCESS:
                OnSuccess();
                CleanUp();
                break;
            case TaskStatus.ABORTED:
                OnAbort();
                CleanUp();
                break;
            case TaskStatus.FAIL:
                OnFail();
                CleanUp();
                break;
            case TaskStatus.DETACHED:
            case TaskStatus.PENDING:
                break;
            default:
                break;
        }
    }

    public Task NextTask { get; private set; }

    public Task Then(Task task)
    {
        NextTask = task;
        return task;
    }

    public void Abort()
    {
        SetStatus(TaskStatus.ABORTED);
    }

    public bool IsDetached { get { return Status == TaskStatus.DETACHED; } }
    public bool IsAttached { get { return Status != TaskStatus.DETACHED; } }
    public bool IsPending { get { return Status == TaskStatus.PENDING; } }
    public bool IsWorking { get { return Status == TaskStatus.WORKING; } }
    public bool IsSuccessful { get { return Status == TaskStatus.SUCCESS; } }
    public bool IsFailed { get { return Status == TaskStatus.FAIL; } }
    public bool IsAborted { get { return Status == TaskStatus.ABORTED; } }
    public bool IsFinished { get { return (Status == TaskStatus.FAIL || Status == TaskStatus.SUCCESS || Status == TaskStatus.ABORTED); } }

    protected virtual void Init()
    {
    }

    internal virtual void Update()
    {
    }

    protected virtual void CleanUp()
    {
    }

    protected virtual void OnAbort()
    {
    }

    protected virtual void OnSuccess()
    {
    }

    protected virtual void OnFail()
    {
    }
}

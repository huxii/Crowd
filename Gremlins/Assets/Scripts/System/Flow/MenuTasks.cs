using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NextScreenTask : Task
{
    public NextScreenTask() { }

    protected override void Init()
    {
        ((MenuControl)Services.mainController).NextScreen();
        SetStatus(TaskStatus.SUCCESS);
    }
}

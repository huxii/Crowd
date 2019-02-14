using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GearControl : ObjectDragControl
{
    public override void Drag(Vector3 deltaPos, Vector3 mouseClickPos)
    {
        //base.Drag(deltaPos);
        if (!IsLocked() && !IsActivated())
        {
            if (dragAxis > Axis.RZ)
            {
                return;
            }

            Vector3 centerPos = transform.position;
            Vector3 mouseAxis = (mouseClickPos - centerPos).normalized;
            bool isMouseAxisReverted = (mouseAxis.y < 0);

            isMouseDown = true;

            float curValue = deltaValue[(int)dragAxis];
            float newValue = curValue;
            float deltaPosValue = deltaPos.x;

            newValue += ((isAxisRevert != isMouseAxisReverted) ? 1 : -1) * deltaPosValue * 100;
            newValue = Mathf.Min(range.y, Mathf.Max(range.x, newValue));
            deltaValue[(int)dragAxis] = newValue;
        }
    }
}

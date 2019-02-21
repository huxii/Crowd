using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MotorSpriteBehavior : MonoBehaviour
{
    public float speed = 1f;

    private HingeJoint2D hingeJoint;

    // Start is called before the first frame update
    void Start()
    {
        hingeJoint = GetComponent<HingeJoint2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(1))
        {
            JointMotor2D motor = hingeJoint.motor;
            if (motor.motorSpeed == 0)
            {
                motor.motorSpeed = speed;
            }
            else
            {
                motor.motorSpeed = -motor.motorSpeed;
            }

            hingeJoint.motor = motor;
        }
    }
}

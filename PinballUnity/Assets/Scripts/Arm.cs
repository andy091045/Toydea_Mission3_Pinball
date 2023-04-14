using GameManagerNamespace;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Profiling;

public class Arm : MonoBehaviour
{
    public ArmType armtype;

    public float Damper;

    public float RotateAngle;

    const float START_ANGLE = 30.0f;

    Rigidbody rb_;

    HingeJoint hingeJoint_;

    JointSpring jointSpring_;
    float gravity_ => GameManager.Instance.Gravity;

    void Start()
    {
        rb_ = GetComponent<Rigidbody>();
        hingeJoint_ = GetComponent<HingeJoint>();
        jointSpring_ = new JointSpring();
        jointSpring_.spring = Damper;
    }

    // Update is called once per frame
    void Update()
    {
        ControllArm();
    }

    private void FixedUpdate()
    {
        rb_.AddForce(new Vector3(0, 0, gravity_ * Time.deltaTime));
    }

    public enum ArmType
    {
        LeftArm, RightArm
    }

    void ControllArm()
    {        
        if (armtype == ArmType.LeftArm) {            
            jointSpring_.targetPosition = Input.GetKey(KeyCode.A) ? -(RotateAngle - START_ANGLE) : START_ANGLE;
        }
        else
        {
            jointSpring_.targetPosition = Input.GetKey(KeyCode.D) ? RotateAngle - START_ANGLE : -START_ANGLE;
        }
        hingeJoint_.spring = jointSpring_;
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GameManagerNamespace;

public class ArmController : MonoBehaviour
{
    /// <summary>
    /// 左腕
    /// </summary>
    public GameObject LeftArm;

    /// <summary>
    /// 右腕
    /// </summary>
    public GameObject RightArm;

    public float force;

    public float damper;

    public float rotateAngle_;

    const float startAngle_ = 30.0f;

    float gravity_ => GameManager.Instance.gravity_;

    // Start is called before the first frame update
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        ControllArm();
    }

    private void FixedUpdate()
    {
        LeftArm.GetComponent<Rigidbody>().AddForce(new Vector3(0,0, gravity_ *Time.deltaTime));
        RightArm.GetComponent<Rigidbody>().AddForce(new Vector3(0, 0, gravity_ * Time.deltaTime));        
    }

    /// <summary>
    /// 左腕と右腕をコントロール
    /// </summary>
    void ControllArm()
    {
        JointSpring leftJoint = new JointSpring();
        JointSpring rightJoint = new JointSpring();

        leftJoint.spring = force;
        leftJoint.spring = damper;

        rightJoint.spring = force;
        rightJoint.spring = damper;

        if (Input.GetKey(KeyCode.A))
        {
            leftJoint.targetPosition = -(rotateAngle_ - startAngle_);
        }
        else
        {
            leftJoint.targetPosition = startAngle_;
        }

        if (Input.GetKey(KeyCode.D))
        {
            rightJoint.targetPosition = rotateAngle_ - startAngle_;
        }
        else
        {
            rightJoint.targetPosition = -startAngle_;
        }
        LeftArm.GetComponent<HingeJoint>().spring = leftJoint;
        RightArm.GetComponent<HingeJoint>().spring = rightJoint;
    }
}

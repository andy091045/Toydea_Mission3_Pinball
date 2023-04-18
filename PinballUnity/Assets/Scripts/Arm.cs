using GameManagerNamespace;
using NaughtyAttributes;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Profiling;

namespace ArmNamespace
{
    public class Arm : MonoBehaviour
    {
        public ArmType armtype;

        [Label("Arm‚Ì’e«")]
        [SerializeField] private float damper_ = 1000000;

        [Label("Arm‚Ì‰ñ“]”ÍˆÍ")]
        [SerializeField] private float rotateAngle_ = 45;       

        private Rigidbody rb_;

        private HingeJoint hingeJoint_;

        private JointSpring jointSpring_;
        float gravity_ => GameManager.Instance.Gravity;

        private const float START_ANGLE = 30.0f;

        void Start()
        {
            rb_ = GetComponent<Rigidbody>();
            hingeJoint_ = GetComponent<HingeJoint>();
            jointSpring_ = new JointSpring();
            jointSpring_.spring = damper_;
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
            if (TypeIsLeftArm(armtype))
            {
                jointSpring_.targetPosition = Input.GetKey(KeyCode.A) ? -(rotateAngle_ - START_ANGLE) : START_ANGLE;
            }
            else
            {
                jointSpring_.targetPosition = Input.GetKey(KeyCode.D) ? rotateAngle_ - START_ANGLE : -START_ANGLE;
            }
            hingeJoint_.spring = jointSpring_;
        }

        public bool TypeIsLeftArm(ArmType armtype)
        {
            return armtype == ArmType.LeftArm ? true : false;
        }
    }
}


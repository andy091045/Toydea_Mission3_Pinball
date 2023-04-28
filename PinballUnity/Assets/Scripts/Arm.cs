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

        [Label("Arm‚Ì’e«")]
        [SerializeField] private float damper_ = 1000000;        

        public bool KeyDown;

        public float TargetAngle;

        public float StartAngle;

        private Rigidbody rb_;

        private HingeJoint hingeJoint_;

        private JointSpring jointSpring_;
        float gravity_ => GameInput.Instance.Gravity;

        
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

        void ControllArm()
        {
            jointSpring_.targetPosition = KeyDown ? TargetAngle : StartAngle;
            hingeJoint_.spring = jointSpring_;
            KeyDown = false;
        }

    }
}


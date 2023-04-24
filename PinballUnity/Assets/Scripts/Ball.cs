using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GameManagerNamespace;
using System.Threading.Tasks;
using NaughtyAttributes;

namespace BallNamespace
{
    public class Ball : MonoBehaviour
    {
        public delegate void BallFallOutEventHandler(int num, char pointer);
        public static BallFallOutEventHandler OccurBallFallOut;

        [Label("Pinball fall out pinball table")]
        [SerializeField] private Vector3 ballLeaveTable_ = new Vector3(0, 0, -35);
        public float Gravity => GameInput.Instance.Gravity;

        private float bounceMinForce_ => GameInput.Instance.BounceMinForce;

        private float bounceMaxForce_ => GameInput.Instance.BounceMinForce;
        
        private Rigidbody rb_;
        private Vector3 startPosition_;
        private Vector3 normalize_;    

        /// <summary>
        /// ボールの重力ボーナス
        /// </summary>
        private const float BALL_PLUS = 130;

        /// <summary>
        /// BALL_PLUS * gravity_
        /// </summary>
        private float ballForce_;

        void Start()
        {
            rb_ = GetComponent<Rigidbody>();
            startPosition_ = transform.position;
            ballForce_ = BALL_PLUS * Gravity;
            AccelerateObject.OccurAccelerate += GetAccelerateForce;
            BounceObject.OccurBouncePhysic += BounceAddForce;
        }

        void Update()
        {
            //Debug.Log("rb.velocity: " + rb.velocity);            
            ResetBallPos();
        }

        private void FixedUpdate()
        {
            rb_.AddForce(new Vector3(0, 0, ballForce_ * Time.deltaTime));
            normalize_ = rb_.velocity.normalized;
        }        

        private void ResetBallPos()
        {
            if (transform.position.z <= ballLeaveTable_.z)
            {                               
                transform.position = startPosition_;
                OccurBallFallOut(1, '-');
                rb_.Sleep();
            }
        }

        private void BounceAddForce(Collision collision)
        {
            Vector3 normal = collision.contacts[0].normal;
            Vector3 bounceDirection = Vector3.Reflect(normalize_, normal);
            float bounceSpeed = Mathf.Clamp(rb_.velocity.magnitude, bounceMinForce_, bounceMaxForce_);
            Vector3 newVelocity = bounceDirection * bounceSpeed;
            rb_.velocity = newVelocity;
        }

        private void GetAccelerateForce(AccelerateObject obj)
        {
            if (obj.isInAccelerateRegion_)
            {
                rb_.AddForce(rb_.velocity.normalized * obj.accelerateAddForce_, ForceMode.Force);
            }
        }

        private void OnDestroy()
        {
            OccurBallFallOut = null;
        }
    }
}

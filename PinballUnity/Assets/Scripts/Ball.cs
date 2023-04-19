using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GameManagerNamespace;
using BounceManagerNamespace;
using System.Threading.Tasks;
using NaughtyAttributes;

namespace BallNamespace
{
    public class Ball : MonoBehaviour
    {
        [Label("Pinball fall out pinball table")]
        [SerializeField] private Vector3 ballLeaveTable_ = new Vector3(0, 0, -35);
        private float gravity_ => GameManager.Instance.Gravity;
        private float accelerateForce_ => GameManager.Instance.AccelerateManager.AccelerateForce;

        private float bounceMinForce_ => GameManager.Instance.BounceManager.BounceMinForce;

        private float bounceMaxForce_ => GameManager.Instance.BounceManager.BounceMinForce;
        
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
            ballForce_ = BALL_PLUS * gravity_;
            GameManager.Instance.AccelerateManager.OccurAccelerate += AccelerateAddForce;
            GameManager.Instance.BounceManager.OccurBouncePhysic += BounceAddForce;
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
                GameManager.Instance.LifeManager.LifeCount(1,'-');
                transform.position = startPosition_;
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

        private void AccelerateAddForce(bool isInAccelerateRegion, float AccelerateAddForce, Collider collider)
        {
            if (isInAccelerateRegion)
            {
                rb_.AddForce(rb_.velocity.normalized * accelerateForce_, ForceMode.Force);
            }
        }
    }
}

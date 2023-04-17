using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GameManagerNamespace;
using AccelerateManagerNamespace;
using BounceManagerNamespace;
using System.Threading.Tasks;

namespace BallNamespace
{
    public class Ball : MonoBehaviour
    {
        public Vector3 BallLeave = new Vector3(0, 0, -35);
        float gravity_ => GameManager.Instance.Gravity;
        float acceleration_ => AccelerateManager.Instance.Acceleration;

        float bounceMinForce_ => BounceManager.Instance.BounceMinForce;

        float bounceMaxForce_ => BounceManager.Instance.BounceMinForce;
        
        Rigidbody rb_;
        Vector3 startPosition_;
        Vector3 normalize_;
        bool isInsideAccelerate_ = false;

        /// <summary>
        /// ボールの重力ボーナス
        /// </summary>
        const float BALL_PLUS = 130;

        float ballForce_;

        // Start is called before the first frame update
        void Start()
        {
            rb_ = GetComponent<Rigidbody>();
            startPosition_ = transform.position;
            ballForce_ = BALL_PLUS * gravity_;
        }

        // Update is called once per frame
        void Update()
        {
            //Debug.Log("rb.velocity: " + rb.velocity);            
            ResetBallPos();
        }

        private void FixedUpdate()
        {
            rb_.AddForce(new Vector3(0, 0, ballForce_ * Time.deltaTime));
            normalize_ = rb_.velocity.normalized;

            TryAccelerate();
        }

        private void OnCollisionEnter(Collision collision)
        {
            if (collision.gameObject.CompareTag("bounceObject_"))
            {
                CollideBounceObjectReflect(collision);
            }            
        }

        private void OnTriggerEnter(Collider collision)
        {
            if (collision.CompareTag("accelerateRegion_"))
            {
                Physics.IgnoreCollision(collision, GetComponent<Collider>(), true);
            }
        }

        private void OnTriggerStay(Collider collision)
        {
            if (collision.CompareTag("accelerateRegion_"))
            {
                isInsideAccelerate_ = true;
            }
        }

        private void OnTriggerExit(Collider collision)
        {
            if (collision.CompareTag("accelerateRegion_"))
            {
                isInsideAccelerate_ = false;
                Physics.IgnoreCollision(collision, GetComponent<Collider>(), false);
            }
        }

        private void ResetBallPos()
        {
            if (transform.position.z <= BallLeave.z)
            {
                transform.position = startPosition_;
                rb_.Sleep();
            }
        }


        private void TryAccelerate()
        {
            if (isInsideAccelerate_)
            {
                rb_.AddForce(rb_.velocity.normalized * acceleration_, ForceMode.Force);
            }
        }

        private void CollideBounceObjectReflect(Collision collision)
        {
            Vector3 normal = collision.contacts[0].normal;
            Vector3 bounceDirection = Vector3.Reflect(normalize_, normal);
            float bounceSpeed = Mathf.Clamp(rb_.velocity.magnitude, bounceMinForce_, bounceMaxForce_);
            Vector3 newVelocity = bounceDirection * bounceSpeed;
            rb_.velocity = newVelocity;
        }

        
    }
}

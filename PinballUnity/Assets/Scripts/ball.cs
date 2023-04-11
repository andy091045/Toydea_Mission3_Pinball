using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GameManagerNamespace;
using AccelerateManagerNamespace;
using UnityEngine.XR;

namespace BallNamespace
{
    public class Ball : MonoBehaviour
    {
        public float bounce = 1.5f;
        public BallExtra controller;
        Vector3 startPosition_;
        float gravity_ => GameManager.Instance.controller.Gravity;
        float acceleration => AccelerateManager.Instance.controller.acceleration;

        Rigidbody rb;
        Vector3 velocity;
        Vector3 normalize;     

        private bool isInsideAccelerate_ = false;

        // Start is called before the first frame update
        void Start()
        {
            rb = GetComponent<Rigidbody>();
            controller = new BallExtra();
            startPosition_ = this.transform.position;
        }

        // Update is called once per frame
        void Update()
        {
            //Debug.Log("rb.velocity: " + rb.velocity);
            if (this.transform.position.z <= -35)
            {
                this.transform.position = startPosition_;
                GetComponent<Rigidbody>().Sleep();
            }
        }

        private void OnCollisionEnter(Collision collision)
        {
            if (collision.gameObject.tag == "bounceObject_")
            {
                Rigidbody rb1 = GetComponent<Rigidbody>();
                Debug.Log(rb1.velocity);
                Debug.Log(rb.velocity);
                Debug.Log(velocity);
                Vector3 normal = collision.contacts[0].normal;
                Vector3 bounceDirection = Vector3.Reflect(normalize, normal);
                float bounceSpeed = velocity.magnitude * bounce;

                Vector3 newVelocity = bounceDirection * bounceSpeed;                
                rb.velocity = newVelocity;
            }
        }

        private void OnTriggerEnter(Collider collision)
        {
            if (collision.gameObject.tag == "accelerateRegion_")
            {
                Physics.IgnoreCollision(collision, GetComponent<Collider>(), true);
            }
        }

        private void OnTriggerStay(Collider collision)
        {
            if (collision.gameObject.tag == "accelerateRegion_")
            {
                isInsideAccelerate_ = true;
                Debug.Log(isInsideAccelerate_);
            }
        }

        private void OnTriggerExit(Collider collision)
        {
            if (collision.gameObject.tag == "accelerateRegion_")
            {
                isInsideAccelerate_ = false;
                Physics.IgnoreCollision(collision, GetComponent<Collider>(), false);
                Debug.Log(isInsideAccelerate_);
            }
        }



        private void FixedUpdate()
        {
            velocity = rb.velocity;
            velocity.z += gravity_ * Time.deltaTime;
            rb.velocity = velocity;
            normalize = rb.velocity.normalized;
            //GetComponent<Rigidbody>().AddForce(new Vector3(0, 0,  gravity_ * Time.deltaTime));
            if (isInsideAccelerate_)
            {
                Rigidbody rb = GetComponent<Rigidbody>();
                rb.AddForce(rb.velocity.normalized * acceleration, ForceMode.Force);
            }
        }
    }

    public class BallExtra
    {
        
    }

}

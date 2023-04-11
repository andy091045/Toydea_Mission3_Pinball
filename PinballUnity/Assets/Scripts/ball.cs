using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GameManagerNamespace;
using AccelerateManagerNamespace;

namespace BallNamespace
{
    public class Ball : MonoBehaviour
    {
        public BallExtra controller;
        Vector3 startPosition_;
        float gravity_ => GameManager.Instance.controller.Gravity;
        float acceleration => AccelerateManager.Instance.controller.acceleration;

        private bool isInsideAccelerate_ = false;

        // Start is called before the first frame update
        void Start()
        {
            startPosition_ = this.transform.position;
        }

        // Update is called once per frame
        void Update()
        {
            if (this.transform.position.z <= -35)
            {
                this.transform.position = startPosition_;
                GetComponent<Rigidbody>().Sleep();
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
            GetComponent<Rigidbody>().AddForce(new Vector3(0, 0, gravity_ * Time.deltaTime));
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

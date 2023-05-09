using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Threading.Tasks;
using NaughtyAttributes;

namespace BallNamespace
{
    public class Ball : MonoBehaviour
    {
        [Label("Pinball fall out pinball table")]
        [SerializeField] private Vector3 ballLeaveTable_ = new Vector3(0, 0, -35);
        private float gravity_ => GameInput.Instance.Gravity;       
        
        private Rigidbody rb_;
        private Vector3 startPosition_;
        private Vector3 normalize_;    

        /// <summary>
        /// ボールの重力ボーナス
        /// </summary>
        private const float BALL_PLUS = 130;

        void Start()
        {
            GameEvent.OccurAccelerate += GetAddForce;
            GameEvent.OccurBouncePhysic += GetAddForce;
            rb_ = GetComponent<Rigidbody>();
            startPosition_ = transform.position;                      
        }

        void Update()
        {
            //Debug.Log("rb.velocity: " + rb.velocity);            
            ResetBallPos();
            BallTryMove();
        }

        private void FixedUpdate()
        {
            rb_.AddForce(new Vector3(0, 0, BALL_PLUS * gravity_ * Time.deltaTime));
            normalize_ = rb_.velocity.normalized;
        }        

        private void ResetBallPos()
        {
            if (transform.position.z <= ballLeaveTable_.z)
            {                               
                transform.position = startPosition_;
                GameEvent.OccurBallFallOut(1, '-');
                rb_.Sleep();
            }
        }
        
        private void GetAddForce(Vector3 addForce)
        {
            rb_.velocity = addForce;
        }
        

        private void BallTryMove() {
            if(GameInput.Instance.BallCanMove) { 
                rb_.isKinematic = false;
            }
            else
            {
                rb_.isKinematic = true;
            }
        }

        private void OnDestroy()
        {
            GameEvent.OccurAccelerate -= GetAddForce;
            GameEvent.OccurBouncePhysic -= GetAddForce;
        }
    }
}

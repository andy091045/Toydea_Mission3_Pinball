using HD.Singleton;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using NaughtyAttributes;

namespace BounceManagerNamespace
{
    public class BounceManager : MonoBehaviour
    {
        public delegate void BounceAddScoreEventHandler(int score);
        public event BounceAddScoreEventHandler OccurBounceAddScore;

        public delegate void BouncePhysicEventHandler(Collision collision);
        public event BouncePhysicEventHandler OccurBouncePhysic;

        /// <summary>
        /// tag = "bounceObject_" MaxSpeed
        /// </summary>
        public float BounceMaxForce = 200;

        /// <summary>
        /// tag = "bounceObject_" MinSpeed
        /// </summary>
        public float BounceMinForce = 150;        

        public void CollideEnterBall(int score, Collision collision)
        {
            OccurBounceAddScore(score);
            OccurBouncePhysic(collision);
        }
    }

}

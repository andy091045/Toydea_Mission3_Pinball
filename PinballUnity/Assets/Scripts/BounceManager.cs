using HD.Singleton;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BounceManagerNamespace
{
    public class BounceManager : TSingletonMonoBehavior<BounceManager>
    {
        public delegate void OccurBounceEventHandler(int score);
        public event OccurBounceEventHandler OccurBounce;

        /// <summary>
        /// tag = "bounceObject_" MaxSpeed
        /// </summary>
        public float BounceMaxForce;

        /// <summary>
        /// tag = "bounceObject_" MinSpeed
        /// </summary>
        public float BounceMinForce;

        public void CollideEnterBall(int score)
        {
            OccurBounce(score);
        }
    }

}

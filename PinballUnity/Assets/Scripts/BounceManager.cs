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
        public delegate void OccurBounceEventHandler(int score);
        public event OccurBounceEventHandler OccurBounce;

        /// <summary>
        /// tag = "bounceObject_" MaxSpeed
        /// </summary>
        public float BounceMaxForce = 200;

        /// <summary>
        /// tag = "bounceObject_" MinSpeed
        /// </summary>
        public float BounceMinForce = 150;
        
        [Label("バウンススコア")]
        public int oneBounceScore_ = 1000;

        public void CollideEnterBall(int score)
        {
            OccurBounce(score);
        }
    }

}

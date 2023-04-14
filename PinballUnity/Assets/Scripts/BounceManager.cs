using HD.Singleton;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BounceManagerNamespace
{
    public class BounceManager : TSingletonMonoBehavior<BounceManager>
    {        
        /// <summary>
        /// tag = "bounceObject_" Groups
        /// </summary>
        public GameObject[] BounceObjects;

        /// <summary>
        /// tag = "bounceObject_2" Groups
        /// </summary>
        public GameObject[] BounceObjects2;

        /// <summary>
        /// tag = "bounceObject_" MaxSpeed
        /// </summary>
        public float BounceMaxForce;

        /// <summary>
        /// tag = "bounceObject_" MinSpeed
        /// </summary>
        public float BounceMinForce;


        void Start()
        {
        }

        // Update is called once per frame
        void Update()
        {

        }
    }
}

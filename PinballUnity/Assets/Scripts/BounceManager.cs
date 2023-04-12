using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BounceManagerNamespace
{
    public class BounceManager : MonoBehaviour
    {        
        public static BounceManager Instance;
        public BounceManagerExtra controller;
        private void Awake()
        {
            Instance = this;
        }
        void Start()
        {
        }

        // Update is called once per frame
        void Update()
        {

        }
    }

    [Serializable]
    public class BounceManagerExtra
    {
        /// <summary>
        /// tag = "bounceObject_" Groups
        /// </summary>
        public GameObject[] bounceObjects;

        /// <summary>
        /// tag = "bounceObject_2" Groups
        /// </summary>
        public GameObject[] bounceObjects2;

        /// <summary>
        /// tag = "bounceObject_" bounceForce
        /// </summary>
        public float bounceForce_;

        /// <summary>
        /// tag = "bounceObject_2" bounceForce
        /// </summary>
        public float bounceForce_2;
    }
}

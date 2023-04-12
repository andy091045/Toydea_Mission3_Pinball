using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace AccelerateManagerNamespace
{
    public class AccelerateManager : MonoBehaviour
    {
        public static AccelerateManager Instance;
        public AccelerateManagerExtra controller;
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
    public class AccelerateManagerExtra
    {
        /// <summary>
        /// tag = "accelerateRegion_" Groups
        /// </summary>
        public GameObject[] accelerateObjects;
        public float acceleration = 100.0f;
    }
}

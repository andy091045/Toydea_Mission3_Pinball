using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace AccelerateManagerNamespace
{
    public class AccelerateManager : MonoBehaviour
    {
        public static AccelerateManager Instance;
        public float acceleration_ = 100.0f;
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
}

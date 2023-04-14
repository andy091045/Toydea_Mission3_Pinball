using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using HD.Singleton;
using UnityEngine.Pool;

namespace AccelerateManagerNamespace
{
    public class AccelerateManager : TSingletonMonoBehavior<AccelerateManager>
    {
        public float Acceleration = 100.0f; 
    }
}

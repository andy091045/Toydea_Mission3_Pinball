using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace AccelerateManagerNamespace
{
    public class AccelerateManager : MonoBehaviour
    {
        public delegate void OccurAccelerateEventHandler(bool isInAccelerateRegion, float AccelerateAddForce, Collider collider);
        public event OccurAccelerateEventHandler OccurAccelerate;

        [SerializeField] private float accelerateAddForce_ = 500.0f;

        public void TryAccelerate(bool isInAccelerateRegion, Collider collider)
        {
            OccurAccelerate(isInAccelerateRegion, accelerateAddForce_, collider);
        }
    }
}


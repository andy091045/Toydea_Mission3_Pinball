using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace AccelerateManagerNamespace
{
    public class AccelerateManager : MonoBehaviour
    {
        [SerializeField] private float accelerateAddForce_ = 500.0f;

        private void Start()
        {
            AccelerateObject.OccurAccelerate += SetAccelerateValue;
        }

        void SetAccelerateValue(AccelerateObject obj)
        {
            obj.GetAccelerateValue(accelerateAddForce_);
        }
    }
}


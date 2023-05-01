using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GameManagerNamespace;

public class AccelerateObject : TriggerObject
{
    public delegate void OccurAccelerateEventHandler(Vector3 addforce);
    public static OccurAccelerateEventHandler OccurAccelerate;

    public float AccelerateAddForce
    {
        get => GameInput.Instance.AccelerateForce;
    }

    protected override void onTriggerEnterTag(Collider other)
    {
        Vector3 addForce = other.attachedRigidbody.velocity.normalized * AccelerateAddForce;
        OccurAccelerate(addForce);
    }
}

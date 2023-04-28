using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GameManagerNamespace;

public class AccelerateObject : TriggerObject
{
    public delegate void OccurAccelerateEventHandler(float addforce);
    public static OccurAccelerateEventHandler OccurAccelerate;

    public float AccelerateAddForce
    {
        get => GameInput.Instance.AccelerateForce;
    }

    protected override void onTriggerStayTag(Collider other)
    {
        OccurAccelerate(AccelerateAddForce);
    }
    protected override void onTriggerExitTag(Collider other)
    {
        OccurAccelerate(0);
    }  
}

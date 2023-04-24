using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GameManagerNamespace;

public class AccelerateObject : TriggerObject
{
    public delegate void OccurAccelerateEventHandler(AccelerateObject obj);
    public static OccurAccelerateEventHandler OccurAccelerate;

    public float accelerateAddForce_;
    public bool isInAccelerateRegion_ = false;

    protected override void onTriggerStayTag(Collider other)
    {
        isInAccelerateRegion_ = true;
        OccurAccelerate(this);
    }
    protected override void onTriggerExitTag(Collider other)
    {
        isInAccelerateRegion_ = false;
        OccurAccelerate(this);
    }   

    public void GetAccelerateValue(float accelerateAddForce_)
    {
        this.accelerateAddForce_ = accelerateAddForce_;
    }

    private void OnDestroy()
    {
        OccurAccelerate = null;
    }
}

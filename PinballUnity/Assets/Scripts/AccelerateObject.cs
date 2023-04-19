using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GameManagerNamespace;

public class AccelerateObject : TriggerObject
{
    [SerializeField] bool isInAccelerateRegion_ = false;
    private Collider accCollider_;
    private void Start()
    {
        accCollider_ = GetComponent<Collider>();
    }
    protected override void onTriggerStayTag(Collider other)
    {
        isInAccelerateRegion_ = true;
        GameManager.Instance.AccelerateManager.TryAccelerate(isInAccelerateRegion_, accCollider_);
    }
    protected override void onTriggerExitTag(Collider other)
    {
        isInAccelerateRegion_ = false;
        GameManager.Instance.AccelerateManager.TryAccelerate(isInAccelerateRegion_, accCollider_);
    }   
}

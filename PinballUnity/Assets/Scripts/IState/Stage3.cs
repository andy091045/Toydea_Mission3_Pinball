using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using StateManagerNamespace;
using GameManagerNamespace;

public class Stage3 : StateBase
{
    private float recordOriginGravity_;

    private float recordOriginBounceMaxForce_;

    private float recordOriginBounceMinForce_;

    public Stage3(StateManager m) : base(m)
    {
    }

    public override void OnEnter()
    {
        //LIÍÌåêêy
        recordOriginGravity_ = GameManager.Instance.Gravity;
        GameManager.Instance.Gravity = recordOriginGravity_ * 2.0f;

        recordOriginBounceMaxForce_ = GameManager.Instance.BounceManager.BounceMaxForce;
        GameManager.Instance.BounceManager.BounceMaxForce = recordOriginBounceMaxForce_ * 1.3f;

        recordOriginBounceMinForce_ = GameManager.Instance.BounceManager.BounceMinForce;
        GameManager.Instance.BounceManager.BounceMinForce = recordOriginBounceMinForce_ * 1.3f;

        //VJnºJ¹CÁãºJVÁÁ

        //LóðLVã{ºÒIè¶¨½¹IâX¨(åÖ)CÁãn`n
        GameManager.Instance.MissionManager.IsStage3MissionStart = true;
    }

    public override void OnExit()
    {
        //Ò´LIÍ
        GameManager.Instance.Gravity = recordOriginGravity_;

        GameManager.Instance.BounceManager.BounceMaxForce = recordOriginBounceMaxForce_;

        GameManager.Instance.BounceManager.BounceMinForce = recordOriginBounceMinForce_;

        //èÂºJVÁÁ 

        //èÂn`n        
        GameManager.Instance.MissionManager.IsStage3MissionStart = false;
    }

    public override void OnUpdate()
    {

    }   
}

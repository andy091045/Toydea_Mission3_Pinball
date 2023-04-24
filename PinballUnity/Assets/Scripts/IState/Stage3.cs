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
        //Š—L“I—ÍÌ‘åˆêêy
        recordOriginGravity_ = GameInput.Instance.Gravity;
        GameInput.Instance.Gravity = recordOriginGravity_ * 2.0f;

        recordOriginBounceMaxForce_ = GameInput.Instance.BounceMaxForce;
        GameInput.Instance.BounceMaxForce = recordOriginBounceMaxForce_ * 1.3f;

        recordOriginBounceMinForce_ = GameInput.Instance.BounceMinForce;
        GameInput.Instance.BounceMinForce = recordOriginBounceMinForce_ * 1.3f;

        //“VŸ†ŠJn‰º‰J—¹C‰Áã‰º‰J“V“ÁÁ

        //—LŒó˜ğ—L“Vã{‰º˜Ò“Iè¶•¨ˆ½’¹“IâX•¨(‘å•Ö)C‰Áã–n`Œn“
        GameManager.Instance.MissionManager.IsStage3MissionStart = true;
    }

    public override void OnExit()
    {
        //ŠÒŒ´Š—L“I—Í
        GameInput.Instance.Gravity = recordOriginGravity_;

        GameInput.Instance.BounceMaxForce = recordOriginBounceMaxForce_;

        GameInput.Instance.BounceMinForce = recordOriginBounceMinForce_;

        //è•Â‰º‰J“V“ÁÁ 

        //è•Â–n`Œn“        
        GameManager.Instance.MissionManager.IsStage3MissionStart = false;
    }

    public override void OnUpdate()
    {

    }   
}

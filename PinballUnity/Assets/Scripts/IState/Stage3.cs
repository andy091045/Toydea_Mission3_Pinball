using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using StateManagerNamespace;

public class Stage3 : StateBase
{
    private string name = "Stage3";

    private float recordOriginGravity_;

    private float recordOriginBounceMaxForce_;

    private float recordOriginBounceMinForce_;

    public Stage3(StateManager m) : base(m)
    {
    }

    public override void OnEnter()
    {
        GameEvent.AnnounceState(name, "OnEnter");
        GameInput.Instance.BallCanMove = false;
        Debug.Log("進入stage3");
        //所有的力變大一點
        recordOriginGravity_ = GameInput.Instance.Gravity;
        GameInput.Instance.Gravity = recordOriginGravity_ * 1.5f;

        recordOriginBounceMaxForce_ = GameInput.Instance.BounceMaxForce;
        GameInput.Instance.BounceMaxForce = recordOriginBounceMaxForce_ * 1.2f;

        recordOriginBounceMinForce_ = GameInput.Instance.BounceMinForce;
        GameInput.Instance.BounceMinForce = recordOriginBounceMinForce_ * 1.2f;

        //天氣開始下雨了，加上下雨天特效

        //有時候會有天上掉下來的雜物或鳥的禮物(大便)，加上墨汁系統
    }

    public override void OnExit()
    {
        GameEvent.AnnounceState(name, "OnExit");
        //還原所有的力
        GameInput.Instance.Gravity = recordOriginGravity_;

        GameInput.Instance.BounceMaxForce = recordOriginBounceMaxForce_;

        GameInput.Instance.BounceMinForce = recordOriginBounceMinForce_;

        //關閉下雨天特效 

        //關閉墨汁系統        
       
    }

    public override void OnUpdate()
    {
        
    }   
}

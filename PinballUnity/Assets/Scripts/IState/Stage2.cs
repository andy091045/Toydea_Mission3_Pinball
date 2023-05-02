using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using StateManagerNamespace;
using GameManagerNamespace;
public class Stage2 : StateBase
{
    private string name = "Stage2";
    public Stage2(StateManager m) : base(m)
    {
    }

    public override void OnEnter()
    {
        GameManager.Instance.AnnounceState(name, "OnEnter");
        GameInput.Instance.BallCanMove = false;
        Debug.Log("進入stage2");
        //啟動可以加血量的道具以及系統
        GameInput.Instance.IsHeartMissionStart = true;        
    }

    public override void OnExit()
    {

        GameManager.Instance.AnnounceState(name, "OnExit");
        //將可以加血量的機制關掉
        GameInput.Instance.IsHeartMissionStart = false;
    }

    public override void OnUpdate()
    {
    }
}

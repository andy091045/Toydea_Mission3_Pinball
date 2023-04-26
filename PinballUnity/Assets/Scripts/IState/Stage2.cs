using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using StateManagerNamespace;
using GameManagerNamespace;
public class Stage2 : StateBase
{
    public delegate void Stage2EventHandler(string state);
    public static Stage2EventHandler OccurStage2;
    public Stage2(StateManager m) : base(m)
    {
    }

    public override void OnEnter()
    {
        GameInput.Instance.BallCanMove = false;
        Debug.Log("進入stage2");
        OccurStage2("OnEnter");
        //啟動可以加血量的道具以及系統
        GameInput.Instance.IsHeartMissionStart = true;
    }

    public override void OnExit()
    {
        //將可以加血量的機制關掉
        GameInput.Instance.IsHeartMissionStart = false;
    }

    public override void OnUpdate()
    {
    }
}

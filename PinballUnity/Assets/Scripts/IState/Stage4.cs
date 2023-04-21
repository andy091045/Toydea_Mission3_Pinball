using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using StateManagerNamespace;
using GameManagerNamespace;

public class Stage4 : StateBase
{
    public Stage4(StateManager m) : base(m)
    {
    }

    public override void OnEnter()
    {
        //將可以加血量的機制關掉
        GameManager.Instance.MissionManager.IsHeartMissionStart = false;

        //因為米奇要開始跑去其他星球幫米妮買禮物，所以會有些區域有其他星球的重力

        //累到人生出現跑馬燈了，所以會有電流急急棒的人生跑馬燈
    }

    public override void OnExit()
    {

    }

    public override void OnUpdate()
    {

    }
}

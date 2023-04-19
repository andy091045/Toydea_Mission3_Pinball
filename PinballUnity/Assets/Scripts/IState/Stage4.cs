using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using StateManagerNamespace;
public class Stage4 : IState
{
    private StateManager stateManager;

    public Stage4(StateManager stateManager)
    {
        this.stateManager = stateManager;
    }

    public void OnEnter()
    {
        //因為米奇要開始跑去其他星球幫米妮買禮物，所以會有些區域有其他星球的重力

        //累到人生出現跑馬燈了，所以會有電流急急棒的人生跑馬燈
    }

    public void OnExit()
    {

    }

    public void OnUpdate()
    {

    }
}

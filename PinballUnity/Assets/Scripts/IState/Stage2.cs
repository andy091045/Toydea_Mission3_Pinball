using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using StateManagerNamespace;
public class Stage2 : IState
{
    private StateManager stateManager;

    public Stage2(StateManager stateManager)
    {
        this.stateManager = stateManager;
    }

    public void OnEnter()
    {

    }

    public void OnExit()
    {

    }

    public void OnUpdate()
    {
        //啟動可以加血量的道具以及系統
    }
}

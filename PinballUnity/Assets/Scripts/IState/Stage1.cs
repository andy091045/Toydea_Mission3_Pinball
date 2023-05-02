using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using StateManagerNamespace;
using GameManagerNamespace;
public class Stage1 : StateBase
{
    private string name = "Stage1";

    public Stage1(StateManager m) : base(m)
    {
    }

    public override void OnEnter()
    {
        GameManager.Instance.AnnounceState(name, "OnEnter");
        GameInput.Instance.BallCanMove = false;        
    }

    public override void OnExit()
    {
        GameManager.Instance.AnnounceState(name, "OnExit");
    }

    public override void OnUpdate()
    {
        
    }
}

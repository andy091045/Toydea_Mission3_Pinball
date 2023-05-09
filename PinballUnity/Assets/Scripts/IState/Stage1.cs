using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using StateManagerNamespace;
public class Stage1 : StateBase
{
    private string name = "Stage1";

    public Stage1(StateManager m) : base(m)
    {
    }

    public override void OnEnter()
    {
        GameEvent.AnnounceState(name, "OnEnter");
        GameInput.Instance.BallCanMove = false;        
    }

    public override void OnExit()
    {
        GameEvent.AnnounceState(name, "OnExit");
    }

    public override void OnUpdate()
    {
        
    }
}

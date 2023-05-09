using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using StateManagerNamespace;

public class Finish : StateBase
{
    private string name = "Finish";
    public Finish(StateManager m) : base(m)
    {
    }

    public override void OnEnter()
    {
        GameEvent.AnnounceState(name, "OnEnter");
        GameInput.Instance.BallCanMove = false;
        Debug.Log("i“üŒ‹Z");
    }

    public override void OnExit()
    {

    }

    public override void OnUpdate()
    {

    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using StateManagerNamespace;
public class Finish : StateBase
{
    public Finish(StateManager m) : base(m)
    {
    }

    public override void OnEnter()
    {
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

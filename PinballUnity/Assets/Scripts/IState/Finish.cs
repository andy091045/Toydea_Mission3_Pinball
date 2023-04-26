using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using StateManagerNamespace;
public class Finish : StateBase
{
    public delegate void FinishEventHandler(string state);
    public static FinishEventHandler OccurFinish;
    public Finish(StateManager m) : base(m)
    {
    }

    public override void OnEnter()
    {
        OccurFinish("OnEnter");
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

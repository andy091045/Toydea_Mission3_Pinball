using StateManagerNamespace;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static Wedding;

public class Wedding : StateBase
{
    public delegate void WeddingEventHandler(string state);
    public static WeddingEventHandler OccurWedding;
    public Wedding(StateManager m) : base(m)
    {
    }

    public override void OnEnter()
    {
        GameInput.Instance.BallCanMove = false;
        OccurWedding("OnEnter");
        //UIæîBounceManager—v˜ôC‰ü
    }

    public override void OnExit()
    {
        OccurWedding("OnExit");
    }

    public override void OnUpdate()
    {

    }
}

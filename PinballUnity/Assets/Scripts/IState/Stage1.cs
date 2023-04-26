using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using StateManagerNamespace;
public class Stage1 : StateBase
{
    public delegate void Stage1EventHandler(string state);
    public static Stage1EventHandler OccurStage1;
    public Stage1(StateManager m) : base(m)
    {
    }

    public override void OnEnter()
    {
        GameInput.Instance.BallCanMove = false;
        OccurStage1("OnEnter");
    }

    public override void OnExit()
    {

    }

    public override void OnUpdate()
    {
        
    }
}

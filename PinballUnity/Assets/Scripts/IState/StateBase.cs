using StateManagerNamespace;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class StateBase
{
    protected StateManager stateManager;

    public StateBase(StateManager m)
    {
        stateManager = m;
    }

    public virtual void OnEnter()
    {

    }

    public virtual void OnUpdate()
    {

    }

    public virtual void OnExit()
    {

    }
}

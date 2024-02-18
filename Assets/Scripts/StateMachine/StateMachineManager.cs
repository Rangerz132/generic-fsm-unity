using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

public class StateMachineManager<EState, TEntity> where EState : Enum
{
    protected Dictionary<EState, BaseState<EState>> states = new Dictionary<EState, BaseState<EState>>();
    protected BaseState<EState> previousState;
    protected BaseState<EState> currentState;

    public TEntity Entity { get; private set; }

    // Constructor
    public StateMachineManager(TEntity entity)
    {
        Entity = entity;
    }

    public void Initialize(EState stateKey)
    {
        previousState = states[stateKey];
        currentState = states[stateKey];
        currentState.EnterState();
    }

    public void UpdateState()
    {
        currentState.UpdateState();
    }

    public void ChangeState(EState stateKey)
    {
        currentState.ExitState();
        previousState = currentState;
        currentState = states[stateKey];
        currentState.EnterState();
    }
}

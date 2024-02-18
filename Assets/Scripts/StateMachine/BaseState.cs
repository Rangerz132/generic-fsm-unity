using System;


public abstract class BaseState<EState> where EState : Enum
{
    // Constructor
    public BaseState(EState stateKey)
    {
        StateKey = stateKey;
    }

    public EState StateKey { get; private set; }

    public abstract void EnterState();
    public abstract void UpdateState();
    public abstract void FixedUpdateState();
    public abstract void ExitState();
}

# Generic Finite State Machine Unity

## Overview

This repository showcases a generic finite state machine (FSM) implementation in Unity. It includes two scenes, each featuring a separate entity with different behaviors. Both entities inherit from the same state machine manager, demonstrating the flexibility and reusability of the FSM design.

## Scene 01

This scene features a basic player controller setup. The player character is controlled by the user and can move along the x and z axes.

The player has two main states:

- Idle State: In this state, the player is stationary.
- Walk State: When the player moves, it transitions to the walk state and moves in the direction specified by the user input.

![](Assets/README/Scene_01.gif)

## Scene 02

In this scene, an enemy character is set up to patrol a predefined route within the scene.

The enemy has two main states:

- Looking State: In this state, the enemy is looking around.
- Patrolling State: In this state, the enemy follows a predefined patrol route.

![](Assets/README/Scene_02.gif)

## Implementation

To implement the generic state machine with the provided classes (StateMachineManager, BaseState, PlayerStateMachine, PlayerIdleState), follow these steps:

1. Define State Enum: Create an enum to represent the possible states of your state machine. For example, PlayerStates.

2. Create State Classes: Create classes that inherit from BaseState to define the behavior for each state. For example, PlayerIdleState.

3. Implement State Behavior: Override the abstract methods in your state classes (EnterState, UpdateState, FixedUpdateState, ExitState) to define the behavior for each state.

4. Create State Machine Manager: Create a class that inherits from StateMachineManager and provides the necessary generic arguments. For example, PlayerStateMachine.

5. Initialize State Machine: In the constructor of your state machine manager, add initial states to the states dictionary.

6. Manage State Changes: Use methods in your state machine manager (Initialize, UpdateState, ChangeState) to manage state transitions and update the current state.

StateMachineManager is a generic class managing states for an entity. It uses an enum EState for state keys. It stores states in a dictionary and tracks the current and previous states. It initializes with an entity and can update and change states, calling state methods EnterState, UpdateState, and ExitState

```csharp
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

```

BaseState is an abstract class representing a state for a state machine. It is generic with EState as an enum for state keys. It has a constructor to set the state key, and abstract methods EnterState, UpdateState, FixedUpdateState, and ExitState for state behavior.

```csharp
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
```

PlayerStateMachine is a specialized StateMachineManager for a Player entity, using PlayerStates enum for state keys. It initializes with a player and adds an Idle state to its dictionary of states, linking it to PlayerIdleState for handling idle behavior.

```csharp
public class PlayerStateMachine : StateMachineManager<PlayerStateMachine.PlayerStates, Player>
{
    public enum PlayerStates
    {
        Idle,
        Walk,
    }

    public PlayerStateMachine(Player player) : base(player)
    {
        states.Add(PlayerStates.Idle, new PlayerIdleState(PlayerStates.Idle, this, player));
        states.Add(PlayerStates.Walk, new PlayerWalkState(PlayerStates.Walk, this, player));
    }
}
```

PlayerIdleState is a state for a Player entity's idle behavior in a PlayerStateMachine. It extends BaseState with PlayerStateMachine.PlayerStates as the enum for state keys. It handles setting and unsetting an animation key for idle state in the player's animator component, with placeholders for UpdateState and FixedUpdateState methods.

```csharp
public class PlayerIdleState : BaseState<PlayerStateMachine.PlayerStates>
{
    private PlayerStateMachine playerStateMachine;
    private Player player;
    private string animationKey = "isIdle";

    public PlayerIdleState(PlayerStateMachine.PlayerStates stateKey, PlayerStateMachine playerStateMachine, Player player) : base(stateKey)
    {
        this.playerStateMachine = playerStateMachine;
        this.player = player;
    }

    public override void EnterState()
    {
        player.Animator.SetBool(animationKey, true);
    }

    public override void ExitState()
    {
        player.Animator.SetBool(animationKey, false);
    }

    public override void UpdateState()
    {

    }

    public override void FixedUpdateState()
    {

    }
}

```

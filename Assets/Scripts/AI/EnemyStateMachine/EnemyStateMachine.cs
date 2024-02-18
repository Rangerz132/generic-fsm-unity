using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyStateMachine : StateMachineManager<EnemyStateMachine.EnemyStates, Enemy>
{
    public enum EnemyStates
    {
        Looking,
        Patrolling,
    }

    public EnemyStateMachine(Enemy enemy) : base(enemy)
    {

        states.Add(EnemyStates.Looking, new EnemyLookingState(EnemyStates.Looking, this, enemy));
        states.Add(EnemyStates.Patrolling, new EnemyPatrollingState(EnemyStates.Patrolling, this, enemy));
    }
}

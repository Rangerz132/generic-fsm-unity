using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyLookingState : BaseState<EnemyStateMachine.EnemyStates>
{
    private EnemyStateMachine enemyStateMachine;
    private Enemy enemy;
    private string animationKey = "isLooking";

    public EnemyLookingState(EnemyStateMachine.EnemyStates stateKey, EnemyStateMachine enemyStateMachine, Enemy enemy) : base(stateKey)
    {
        this.enemyStateMachine = enemyStateMachine;
        this.enemy = enemy;
    }

    public override void EnterState()
    {
        enemy.Animator.SetBool(animationKey, true);
    }

    public override void ExitState()
    {
        enemy.Animator.SetBool(animationKey, false);
    }

    public override void UpdateState()
    {
        enemy.Patrol.LookAround();

        if (enemy.Patrol.IsDoneLooking())
        {
            enemy.Patrol.SetNextDestination();
            enemyStateMachine.ChangeState(EnemyStateMachine.EnemyStates.Patrolling);
        }
    }

    public override void FixedUpdateState()
    {

    }
}

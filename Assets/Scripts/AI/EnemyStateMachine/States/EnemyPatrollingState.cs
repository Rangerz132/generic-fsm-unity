using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPatrollingState : BaseState<EnemyStateMachine.EnemyStates>
{
    private EnemyStateMachine enemyStateMachine;
    private Enemy enemy;
    private string animationKey = "isPatrolling";

    public EnemyPatrollingState(EnemyStateMachine.EnemyStates stateKey, EnemyStateMachine enemyStateMachine, Enemy enemy) : base(stateKey)
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
        HandleMovement();
    }

    public override void FixedUpdateState()
    {

    }

    /// <summary>
    /// Move enemy to the target destination
    /// </summary>
    private void HandleMovement()
    {
        if (!enemy.Patrol.DestinationReached())
        {
            enemy.transform.position = Vector3.MoveTowards(enemy.transform.position, enemy.Patrol.TargetDestination, enemy.MovementSO.speed * Time.deltaTime);

            Vector3 targetDirection = enemy.Patrol.TargetDestination - enemy.transform.position;
            Quaternion targetRotation = Quaternion.LookRotation(targetDirection);
            enemy.transform.rotation = Quaternion.Slerp(enemy.transform.rotation, targetRotation, enemy.MovementSO.rotationSpeed * Time.deltaTime);
        }
        else
        {
            enemy.transform.position = enemy.Patrol.TargetDestination;
            enemyStateMachine.ChangeState(EnemyStateMachine.EnemyStates.Looking);
        }
    }
}

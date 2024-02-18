using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    private EnemyStateMachine enemyStateMachine;
    [field: SerializeField] public Animator Animator { get; private set; }
    [field: SerializeField] public Patrol Patrol { get; private set; }
    [field: SerializeField] public MovementSO MovementSO { get; private set; }

    void Start()
    {
        enemyStateMachine = new EnemyStateMachine(this);
        enemyStateMachine.Initialize(EnemyStateMachine.EnemyStates.Looking);
    }

    void Update()
    {
        enemyStateMachine.UpdateState();
    }
}

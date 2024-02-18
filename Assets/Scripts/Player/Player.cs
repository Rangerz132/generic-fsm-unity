using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private PlayerStateMachine playerStateMachine;
    [field: SerializeField] public PlayerInputManager PlayerInputManager { get; private set; }
    [field: SerializeField] public Animator Animator { get; private set; }
    [field: SerializeField] public MovementSO MovementSO { get; private set; }

    private void Start()
    {
        playerStateMachine = new PlayerStateMachine(this);
        playerStateMachine.Initialize(PlayerStateMachine.PlayerStates.Idle);
    }

    private void Update()
    {
        playerStateMachine.UpdateState();
    }
}

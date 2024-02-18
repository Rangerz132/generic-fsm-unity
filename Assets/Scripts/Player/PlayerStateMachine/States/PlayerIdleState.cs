using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
        HandleMovement();
    }

    public override void FixedUpdateState()
    {

    }

    private void HandleMovement()
    {
        Vector2 inputVector = player.PlayerInputManager.GetVector2Normalized(player.PlayerInputManager.moveAction);
        Vector3 moveDirection = new Vector3(inputVector.x, 0, inputVector.y);

        if (moveDirection != Vector3.zero)
        {
            playerStateMachine.ChangeState(PlayerStateMachine.PlayerStates.Walk);
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerWalkState : BaseState<PlayerStateMachine.PlayerStates>
{
    private PlayerStateMachine playerStateMachine;
    private Player player;
    private string animationKey = "isWalking";
    private bool isMoving;

    public PlayerWalkState(PlayerStateMachine.PlayerStates stateKey, PlayerStateMachine playerStateMachine, Player player) : base(stateKey)
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

    /// <summary>
    /// Move player based on the inputs
    /// </summary>
    private void HandleMovement()
    {
        Vector2 inputVector = player.PlayerInputManager.GetVector2Normalized(player.PlayerInputManager.moveAction);
        Vector3 moveDirection = new Vector3(inputVector.x, 0, inputVector.y);

        float moveDistance = player.MovementSO.speed * Time.deltaTime;
        player.transform.position += moveDirection * moveDistance;

        isMoving = moveDirection != Vector3.zero;

        Quaternion currentRotation;
        currentRotation = player.transform.rotation;


        if (isMoving = moveDirection != Vector3.zero)
        {
            Quaternion targetRotation = Quaternion.LookRotation(moveDirection);
            player.transform.rotation = Quaternion.Slerp(currentRotation, targetRotation, player.MovementSO.rotationSpeed * Time.deltaTime);
        }
        else
        {
            playerStateMachine.ChangeState(PlayerStateMachine.PlayerStates.Idle);
        }
    }
}

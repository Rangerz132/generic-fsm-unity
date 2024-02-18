using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInputManager : MonoBehaviour
{
    [SerializeField] private InputActionAsset playerInputActions;
    [SerializeField] private string actionMapName = "Player";

    private string moveInputActonName = "Move";

    public InputAction moveAction;

    public Vector2 MoveInput { get; private set; }

    private void Awake()
    {
        moveAction = playerInputActions.FindActionMap(actionMapName).FindAction(moveInputActonName);
        RegisterInputActions();
    }

    private void RegisterInputActions()
    {
        moveAction.performed += context => MoveInput = context.ReadValue<Vector2>();
        moveAction.canceled += context => MoveInput = Vector2.zero;
    }

    private void OnEnable()
    {
        moveAction.Enable();
    }

    private void OnDisable()
    {
        moveAction.Disable();
    }

    public Vector2 GetVector2Normalized(InputAction inputAction)
    {
        Vector2 inputVector = inputAction.ReadValue<Vector2>();
        inputVector = inputVector.normalized;
        return inputVector;
    }
}

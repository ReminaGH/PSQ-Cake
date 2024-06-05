using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameInput : MonoBehaviour
{

    private PlayerControlls playerControlls;

    public event EventHandler OnJump;
    public event EventHandler OnInteract;
    public event EventHandler OnInteractAlt;

    private void Awake()
    {
        playerControlls = new PlayerControlls();
        
    }

    //Unsubscribes events from the memory when the game and or player is not around
    private void OnDisable()
    {
        playerControlls.Player.Disable();
        playerControlls.Player.Interact.performed -= Interact_performed;
        playerControlls.Player.InteractAlt.performed -= InteractAlt_performed;
    }

    //Enables the events in memory
    private void OnEnable()
    {
        playerControlls.Player.Enable();
        playerControlls.Player.Interact.performed += Interact_performed;
        playerControlls.Player.InteractAlt.performed += InteractAlt_performed;
        playerControlls.Player.Jump.performed += Jump_performed;

    }

    //Events that invoke and are called to whenever an action is performed
    private void Jump_performed(UnityEngine.InputSystem.InputAction.CallbackContext obj)
    {
        OnJump?.Invoke(this, EventArgs.Empty);
    }

    private void InteractAlt_performed(UnityEngine.InputSystem.InputAction.CallbackContext obj)
    {
        OnInteractAlt?.Invoke(this, EventArgs.Empty);
    }

    private void Interact_performed(UnityEngine.InputSystem.InputAction.CallbackContext obj)
    {
        OnInteract?.Invoke(this, EventArgs.Empty);
    }

    //Movement normalized, meaning it takes into account multiple directions without adding their combined movment
    public Vector2 GetMovementNormalized() { 
        Vector2 inputVector = playerControlls.Player.Move.ReadValue<Vector2>();

        inputVector = inputVector.normalized;

        return inputVector;
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameInput : MonoBehaviour
{

    private PlayerControlls playerControlls;

    private void Awake()
    {
        playerControlls = new PlayerControlls();
        
    }

    private void OnEnable()
    {
        playerControlls.Player.Enable();
    }

    private void OnDisable()
    {
        playerControlls.Player.Disable();
    }

    public Vector2 GetMovementNormalized() { 
        Vector2 inputVector = playerControlls.Player.Move.ReadValue<Vector2>();

        inputVector = inputVector.normalized;

        return inputVector;
    }
}

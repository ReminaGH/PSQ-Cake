using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour
{
   
    [SerializeField] private float moveSpeed = 7f;
    [SerializeField] private GameInput gameInput;

    public Rigidbody2D rb;
    private bool isWalking;
    Vector2 moveDir = Vector2.zero;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {

        moveDir = gameInput.GetMovementNormalized();

    }

    private void FixedUpdate()

    {
        rb.velocity = new Vector2(moveDir.x * moveSpeed, moveDir.y * moveSpeed);

    }

    public bool IsWalking() {
        return isWalking;
    }
}

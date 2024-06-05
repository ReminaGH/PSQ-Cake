using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour
{
   
    [SerializeField] private float moveSpeed = 5f;
    [SerializeField] private float jumpForce = 10f;
    [SerializeField] private GameInput gameInput;
    [SerializeField] private Transform groundCheck;

    private bool isGrounded;
    private Rigidbody2D rb;
    private Vector2 moveDir = Vector2.zero;
    private float groundCheckRaidus = 0.2f;

    //Might fix / add later if groundCheck becomes a an issue with other objects.
    //private LayerMask groundLayer; * Currently not working, adding back later


    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    //Subscribes to the events, invoking their actions and function whenever it occurs.
    private void Start()
    {
        gameInput.OnInteract += GameInput_OnInteract;
        gameInput.OnInteractAlt += GameInput_OnInteractAlt;
        gameInput.OnJump += GameInput_OnJump;
    }

    //Jump feature by adding momentum to the rigibody's mass, changed by adjusting the jumpforce variable
    private void GameInput_OnJump(object sender, System.EventArgs e)
    {
        if(isGrounded)
        {
            rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
            Debug.Log("Jump!");
        }
        
        Debug.Log("Jump failed: Not grounded");
    }

    private void GameInput_OnInteractAlt(object sender, System.EventArgs e)
    {
        Debug.Log("Interact alt: F");
    }

    private void GameInput_OnInteract(object sender, System.EventArgs e)
    {
        Debug.Log("Interact: E");
    }

    private void Update()
    {

        moveDir = gameInput.GetMovementNormalized();

    }

    private void FixedUpdate()

    {
        //Checks if the player is groudned by sending a raycast downwards towards the object within the radius of the player's specific check. NOTE: Might not be the best solution
        isGrounded = Physics2D.Raycast(groundCheck.position, Vector2.down, groundCheckRaidus, Physics2D.AllLayers);

        //Movment is added by increasing the velocity of the rigidbody mass, like jumping but in sideways directions
        rb.velocity = new Vector2(moveDir.x * moveSpeed, rb.velocity.y);

    }

    

}

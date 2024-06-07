using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour
{

    public static Player Instance { get; private set; }

    public event EventHandler<OnSelectedObjChangedEventArgs> OnSelectedObjChanged;
    public class OnSelectedObjChangedEventArgs : EventArgs
    {
        public InteractableObj selectedObj;
    }

    [SerializeField] private float moveSpeed = 5f;
    [SerializeField] private float jumpForce = 50f;
    [SerializeField] private GameInput gameInput;
    [SerializeField] private Transform groundCheckObj;
    [SerializeField] private Transform interactCheckObj;
    [SerializeField] private LayerMask groundLayer;
    [SerializeField] private LayerMask interactLayer;

    private Rigidbody2D rb;
    private Vector2 moveDir = Vector2.zero;
    private float groundCheckRadius = 0.2f;
    private float interactCheckRadius = 0.1f;
    private InteractableObj selectedObj;
    private float MoveHorizontal;
    private bool canWalk = true;
    
    public bool isFacingRight;
    public bool hasHammer = false;
    public bool hasKey = false;
    public Animator animator;

    private float GetVerticalSpeed() => rb.velocity.y;


    private void Awake()
    {
        isFacingRight = true;
        Instance = this;
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();

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
        if(isGrounded())
        {

            rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
            Debug.Log("Jump!");

        }
        else { 
        
            Debug.Log("Jump failed: Not grounded");

        }
    }

    public void GameInput_OnInteractAlt(object sender, System.EventArgs e)
    {
        if(selectedObj != null)
        {
            selectedObj.InteractAlt();
            
        }
    }

    private void GameInput_OnInteract(object sender, System.EventArgs e)
    {
        if (selectedObj != null)
        {
            selectedObj.Interact();
            animator.SetTrigger("isInteracting");
        }
    }

    private void Update()
    {
        
        HandleInteraction();
        if(canWalk == true) { 
            moveDir = gameInput.GetMovementNormalized();
        }

}

    private void FixedUpdate()

    {
        
        if(GetVerticalSpeed() < -2f) {
            

            animator.SetBool("isJumping", false);
            
            animator.SetBool("isFalling", true);
        } 
        else if(GetVerticalSpeed() == 0 || GetVerticalSpeed() > 0f) 
        {
            animator.SetBool("isJumping", !isGrounded());
            
            
            animator.SetBool("isFalling", false);
        }

        MoveHorizontal = Input.GetAxisRaw("Horizontal");
        //Movment is added by increasing the velocity of the rigidbody mass, like jumping but in sideways directions
        rb.velocity = new Vector2(moveDir.x * moveSpeed, rb.velocity.y);

        if (MoveHorizontal != 0)
        {
            animator.SetBool("isMoving", true);
        }
        else {
            animator.SetBool("isMoving", false);
        }

        

        if (!isFacingRight && MoveHorizontal > 0)
        {

            Flip();

        } else if (isFacingRight && MoveHorizontal < 0) {

            Flip();

        }

    }
    private void OnDrawGizmos()
    {
        //Visiualizes the check for ground
        if (groundCheckObj != null)
        {

            Gizmos.color = Color.red;
            Gizmos.DrawWireSphere(groundCheckObj.position, groundCheckRadius);

        }

        //Visiualizes the check for ground
        if (interactCheckObj != null)
        {

            Gizmos.color = Color.yellow;
            Gizmos.DrawWireSphere(interactCheckObj.position, interactCheckRadius);

        }
    }



    private bool isGrounded() 
    {

        if (Physics2D.OverlapCircle(groundCheckObj.position, groundCheckRadius, groundLayer))
        { 

            return true;

        }
        else
        {

            return false;

        }

    }

    public bool isInteracting()
    {
        //Returns a bool if the below physics is interacting with an ojbect with the same layer
        return Physics2D.OverlapCircle(interactCheckObj.position, interactCheckRadius, interactLayer);

    }

    private void HandleInteraction() {
       
        //Checks for an objects box and it's layer
        Collider2D overlaphits = Physics2D.OverlapCircle(interactCheckObj.position, interactCheckRadius, interactLayer);

        if (overlaphits != null) 
        { 
            //If it hits, it gets the object's component, which is the object itself
            if (overlaphits.transform.TryGetComponent(out InteractableObj interactableObj))
            {
                //If there is a match, it sets the object to be itself
                if (interactableObj != selectedObj)
                {

                    SetSelectedObj(interactableObj);
                    Debug.Log(interactableObj.name);

                }
                   
            }
                
        }
        //If no match, sets the object to null
        else
        {
            if (selectedObj != null)
            {
                SetSelectedObj(null);
            }

        }
    }

    private void SetSelectedObj(InteractableObj selectedObj)
    {
        //Sets the object to be itself if its a match using an event, making it able to be called from other locations
        this.selectedObj = selectedObj;

        OnSelectedObjChanged?.Invoke(this, new OnSelectedObjChangedEventArgs
        {
            selectedObj = selectedObj
        });
    }

    public void Flip() 
    {

        isFacingRight = !isFacingRight;
        Vector3 localScale = transform.localScale;
        localScale.x *= -1f;
        transform.localScale = localScale;

    }

    public bool WhichDirection() 
    {
        return isFacingRight;
    }

    public void confusedAimationPlayed(float delayTime)
    {
        canWalk = false;
        animator.SetBool("isConfused", true);
        StartCoroutine(Delay(delayTime));
    }

    IEnumerator Delay(float delayTime)
    {
        yield return new WaitForSeconds(delayTime);

        animator.SetBool("isConfused", false);
        canWalk = true;
    }

}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    // Config 
    [SerializeField] float movementSpeed = 5f;
    [SerializeField] float climbingSpeed = 5f;
    [SerializeField] float jumpForce = 5f;
    [SerializeField] Vector2 dieKick = new Vector2(25f, 25f);
    
    // Cached component references
    Rigidbody2D myRigidbody;
    Animator myAnimator;
    CapsuleCollider2D myBodyCollider;
    BoxCollider2D myFeet;
    float gravityScaleAtStart;

    // State
    bool isAlive = true;
    

    void Start()
    {
        myRigidbody = GetComponent<Rigidbody2D>();
        myAnimator = GetComponent<Animator>();
        myBodyCollider = GetComponent<CapsuleCollider2D>();
        myFeet = GetComponent<BoxCollider2D>();
        gravityScaleAtStart = myRigidbody.gravityScale;
    }

    // Update is called once per frame
    void Update()
    {
        if (!isAlive)
        {
            return;
        }

        Run();
        FlipSprite();
        Jump();
        ClimbLadders();
        Die();
    }

    private void Run()
    {
        float horizontalMove = Input.GetAxis("Horizontal");
        myRigidbody.velocity = new Vector2(horizontalMove * movementSpeed, myRigidbody.velocity.y);
        bool playerHasHorizontalSpeed = (Mathf.Abs(myRigidbody.velocity.x) > Mathf.Epsilon); // Mathf.Epsilon equals to 0f
        myAnimator.SetBool("Running", playerHasHorizontalSpeed); //if player has horizontal speed then set bool Running true else if set Running false  
    }

    private void Jump()
    {
        if (!myFeet.IsTouchingLayers(LayerMask.GetMask("Ground")))
        { 
            return; 
        }

        if (Input.GetButtonDown("Jump"))
        {
            Vector2 jumpVelocityToAdd = new Vector2(myRigidbody.velocity.x, jumpForce);
                myRigidbody.velocity += jumpVelocityToAdd;
        }     
    }

    private void ClimbLadders()
    {
        if (!myFeet.IsTouchingLayers(LayerMask.GetMask("Ladder")))
        {   
            myAnimator.SetBool("Climbing", false);
            myRigidbody.gravityScale = gravityScaleAtStart;
            return;
        }

            float verticalMove = Input.GetAxis("Vertical");
            myRigidbody.velocity = new Vector2(myRigidbody.velocity.x, verticalMove * climbingSpeed);
            bool playerHasVerticalSpeed = (Mathf.Abs(myRigidbody.velocity.y) > Mathf.Epsilon);
            myAnimator.SetBool("Climbing", playerHasVerticalSpeed);
            myRigidbody.gravityScale = 0f; 
    }
    
    void Die()
    {
        if (myBodyCollider.IsTouchingLayers(LayerMask.GetMask("Enemy", "Hazards")))
        {
            isAlive = false;
            myAnimator.SetTrigger("Losing");
            myRigidbody.velocity = dieKick;
            FindObjectOfType<GameSession>().Invoke("ProcessPlayerDeath", 1f);
        }
    }

    private void FlipSprite()
    {
        bool playerHasHorizontalSpeed = (Mathf.Abs(myRigidbody.velocity.x) > Mathf.Epsilon);
        if (playerHasHorizontalSpeed)
        {
            transform.localScale = new Vector2(Mathf.Sign(myRigidbody.velocity.x), 1f);
        }
    }
}

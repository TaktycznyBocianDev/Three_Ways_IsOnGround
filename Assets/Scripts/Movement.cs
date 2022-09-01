using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    //Basic movement class. I will allow player to jump,
    //but we need a way to communcate that we stay on ground.
    [Header("What we want to establish")]
    [SerializeField] bool isOnGround;

    [Header("How fast we will run")]
    [SerializeField] float moveSpeed;
    [Header("How strong will be jump")]
    [SerializeField] float jumpForce;

    //Some staff that we need
    bool playerWantJump;
    float horizontalInput;
    SpriteRenderer rend;
    Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rend = GetComponent<SpriteRenderer>();
    }

    //Here we check player input and rotate player character if he move to the left
    void Update()
    {
        horizontalInput = Input.GetAxisRaw("Horizontal");
        CheckIfPlayerWantToJump();
        FlipPlayer();
    }

    private void OnEnable()
    {
        EventManager.onGroundE += SetIsOnGround;
    }

    private void OnDisable()
    {
        EventManager.onGroundE -= SetIsOnGround;
    }

    void SetIsOnGround(bool isGrounded)
    {
        isOnGround = isGrounded;
    }

    //Phisics calculations - movement and jump
    private void FixedUpdate()
    {
        MovePlayer();
        Jump();
    }

    void Jump()
    {
        if (playerWantJump && isOnGround)
        {

                rb.AddForce(new Vector3(0, jumpForce, 0), ForceMode2D.Impulse);
                playerWantJump = false;
                isOnGround = false;

        }
    }
    void MovePlayer()
    {
        rb.velocity = new Vector2(horizontalInput * moveSpeed, rb.velocity.y);
    }
    void FlipPlayer()
    {
        if (horizontalInput >= 0)
        {
            rend.flipX = false;
        }
        else
        {
            rend.flipX = true;
        }
    }
    void CheckIfPlayerWantToJump()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            playerWantJump = true;
        }
    }

}

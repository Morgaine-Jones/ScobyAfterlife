using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    // Variables
    private Rigidbody2D rb;

    public float speed;
    public float jumpForce;
    bool isJumping;
    bool facingRight;

    // Start & Updates
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        facingRight = true;
    }
    void Update()
    {
        Jump();
    }
    void FixedUpdate()
    {
        float horizontal = Input.GetAxis("Horizontal");

        HandleMovement(horizontal);
        Flip(horizontal);

        if (horizontal != 0 && !isJumping)
        {
            GetComponent<Animator>().SetBool("Walking", true);
        }
        else if (horizontal == 0 && !isJumping)
        {
            GetComponent<Animator>().SetBool("Walking", false);
        }
    }

    // Moves player
    private void HandleMovement(float horizontal)
    {
        rb.velocity = new Vector2(horizontal * speed, rb.velocity.y);
    }
    void Flip(float horizontal)
    {
       if (horizontal > 0 && !facingRight || horizontal < 0 && facingRight)
       {
            facingRight = !facingRight;

            Vector3 theScale = transform.localScale;
            theScale.x = theScale.x * -1;
            transform.localScale = theScale;
       }
    }
    void Jump()
    {
        if ((Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.UpArrow)) && !isJumping)
        {
            isJumping = true;
            rb.AddForce(new Vector2(rb.velocity.x, jumpForce));

            GetComponent<Animator>().SetBool("Jumping", true);
        }
    }

    // Checks if player is on ground
    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Ground")) 
        {
            isJumping = false;

            rb.velocity = Vector2.zero;

            GetComponent<Animator>().SetBool("Jumping", false);
        }
    }
}

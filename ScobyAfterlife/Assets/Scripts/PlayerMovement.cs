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

    public GameObject player;

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
        if (Input.GetKeyDown(KeyCode.Space) && !isJumping)
        {
            isJumping = true;
            rb.AddForce(new Vector2(rb.velocity.x, jumpForce));
        }
    }

    // Checks if player is on ground
    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Ground")) 
        {
            isJumping = false;

            rb.velocity = Vector2.zero;
        }
    }
}

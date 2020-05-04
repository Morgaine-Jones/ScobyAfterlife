using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    Rigidbody2D rb;

    float moving = 0f;
    bool jumping = false;

    public float speed;
    public float jumpHeight;

    public bool onGround = false;
    [SerializeField] private Transform GroundCheck;
    bool isFacingRight = true;

    [SerializeField] float JumpForce = 10;
    [Range(0, .3f)] [SerializeField] float MovementSmoothing = 0.05f;
    [SerializeField] bool AirControl = false;
    Vector3 Velocity = Vector3.zero;

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    void Update()
    {
        moving = Input.GetAxisRaw("Horizontal") * speed;

        if (Input.GetButtonDown("Jump"))
        {
            jumping = true;
            Debug.Log("hello1");
        }
    }
    void FixedUpdate()
    {
        Move(moving * Time.fixedDeltaTime, jumping);
        jumping = false;
        Debug.Log("hello2");
    }

    void Move(float move, bool jump)
    {
        if (onGround || AirControl)
        {
            Vector3 targetVelocity = new Vector2(move * 10f, rb.velocity.y);
            rb.velocity = Vector3.SmoothDamp(rb.velocity, targetVelocity, ref Velocity, MovementSmoothing);

            // Flips the player
            if (move > 0 && !isFacingRight)
            {
                Flip();
            }
            else if (move < 0 && isFacingRight)
            {
                Flip();
            }
        }

        // Checks if should jump or not
        if (onGround && jump)
        {
            onGround = false;
            rb.AddForce(new Vector2(0f, JumpForce));
        }
    }
    void Flip()
    {
        isFacingRight = !isFacingRight;

        Vector3 theScale = transform.localScale;
        theScale.x *= -1;
        transform.localScale = theScale;
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.layer == 8)
        {
            onGround = true;
        }
        else onGround = false;
    }
    void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.layer == 8)
        {
            onGround = false;
        }
    }
}

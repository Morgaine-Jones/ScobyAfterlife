using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public CharacterController2D controller;
    Animator anim;

    public float runSpeed = 40f;
    float horizontalMove = 0f;
    bool jump = false;
    bool crouch = false;

    // Update is called once per frame
    void Update()
    {
        horizontalMove = Input.GetAxisRaw("Horizontal") * runSpeed;

        if (Input.GetButtonDown("Horizontal"))
        {
            anim.SetBool("walking", true);
        }
        else 
        {
            anim.SetBool("walking", false);
        }


        if (Input.GetButtonDown("Jump")) 
        {
            jump = true;
            anim.SetBool("Jumping", true);
        }
        if (Input.GetButtonDown("Crouch"))
        {
            crouch = true;
        }
        else if (Input.GetButtonUp("Crouch")) 
        {
            crouch = false;
        }
    }

    private void FixedUpdate()
    {
        controller.Move(horizontalMove * Time.fixedDeltaTime, crouch, jump);
        jump = false; 
    }

    public void OnLanding()
    {
        anim.SetBool("Jumping", false);
    }
}

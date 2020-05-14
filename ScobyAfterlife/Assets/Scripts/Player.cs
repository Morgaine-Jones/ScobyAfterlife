using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public CharacterController2D controller;
    public Animator anim;

    public float runSpeed = 40f;
    float horizontalMove = 0f;
    bool jump = false;

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
            anim.SetBool("jumping", true);
        }
    }

    private void FixedUpdate()
    {
        controller.Move(horizontalMove * Time.fixedDeltaTime, jump);
        jump = false; 
    }

    public void OnLanding()
    {
        anim.SetBool("jumping", false);
    }
}

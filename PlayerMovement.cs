using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public CharacterController2D controller;

    public Animator anim;

    public float runSpeed = 130f;

    float horizontalMove = 0f;
    bool jump = false;
    bool crouch = false;

    void Update()
    {

        horizontalMove = Input.GetAxisRaw("Horizontal") * runSpeed;

        anim.SetFloat("Run", Mathf.Abs(horizontalMove));

        if (Input.GetButton("jump"))
        {
            anim.SetBool("IsJumping", true);    
            jump = true;
        }


        if (Input.GetButtonDown("Crouch"))
        {
            crouch = true;
            jump = false;
        } else if (Input.GetButtonUp("Crouch"))
        {
            crouch = false;
        }

    }

    public void OnLanding()
    {
        anim.SetBool("IsJumping", false);
    }

    public void OnCrouching(bool Crouch)
    {
        anim.SetBool("Crouch", Crouch);
    }

    void FixedUpdate()
    {
        controller.Move(horizontalMove * Time.fixedDeltaTime, crouch, jump);
        jump = false;
    }

    public void OnTriggerEnter2D(Collider2D collect)
    {
        if (collect.gameObject.CompareTag("Gem"))
        {
            Destroy(collect.gameObject);
        }
    }

}


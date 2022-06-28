using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.Design.Serialization;
using UnityEngine;

public class CharacterMovement : MonoBehaviour
{
    public CharacterController2D controller;
    public float horizontalMove = 0f;
    public float runSpeed = 40f;
    public bool jump = false;
    public bool crouch = false;

    private void Update()
    {
        Debug.Log("Update");
        horizontalMove = Input.GetAxisRaw("Horizontal") * runSpeed;
        if (Input.GetButtonDown("Jump"))
        {
            jump = true;
        }

        crouch = Input.GetButton("Crouch");

    }

    private void FixedUpdate()
    {
        Debug.LogWarning("FixedUpdate");
        controller.Move(horizontalMove * Time.fixedDeltaTime,crouch, jump);
        jump = false;


        // Quando apertar para esquerda
        // virar sprite
        // flipSpriteRenderer.flipX = valor

        // animator.SetFloat("Speed", Mathf.Abs(horizontalMove));
        //
        // if(Input.GetMouseButtonDown(0))
        // {
        //     jump = true;
        //     verticalMove = Input.GetAxis("Vertical") * runSpeed;
        //     animator.SetBool("IsJumping", true);
        // }

    }


}

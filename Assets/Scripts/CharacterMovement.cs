using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.Design.Serialization;
using UnityEngine;

public class CharacterMovement : MonoBehaviour
{
    [SerializeField] private float runSpeed = 40f;

    public CharacterController2D controller;

    private float horizontalMove = 0f;
    private float verticalMove;
    private bool jump = false;
    private bool crouch = false;
    private bool dash = false;
    private Vector2 dashDirection;

    private void Update()
    {
        //Debug.Log("Update");
        horizontalMove = Input.GetAxisRaw("Horizontal") * runSpeed;
        verticalMove = Input.GetAxisRaw("Vertical") * runSpeed;

        if (Input.GetButtonDown("Jump"))
        {
            jump = true;
        }

        crouch = Input.GetButton("Crouch");

        if (Input.GetButtonDown("Dash"))
        {
            dash = true;
        }
    }

    private void FixedUpdate()
    {
        if (dash)
        {
            dashDirection = new Vector2(horizontalMove, verticalMove);
            controller.Dash(dashDirection);
            dash = false;
        }
        else
        {
            controller.Move(horizontalMove * Time.fixedDeltaTime, crouch, jump);
            jump = false;
        }
    }


}

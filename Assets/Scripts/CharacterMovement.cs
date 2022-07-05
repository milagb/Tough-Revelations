using System;
using UnityEngine;

public class CharacterMovement : MonoBehaviour
{
    public CharacterController2D controller;

    [SerializeField] private float coolDown = 50;

    private float horizontalInput = 0f;
    private float verticalInput;

    private float dashTriggerTime;
    private bool jumpTrigger = false;
    private bool crouchTrigger = false;
    private bool dashTrigger = false;
    private Vector2 dashDirection;

    [SerializeField] private Animator animator;



    private void Start()
    {
        dashTriggerTime = -coolDown;
    }

    private void Update()
    {
        //Debug.Log("Update");
        horizontalInput = Input.GetAxisRaw("Horizontal");
        verticalInput = Input.GetAxisRaw("Vertical");

        animator.SetFloat("Speed", Math.Abs(horizontalInput));



        if (Input.GetButtonDown("Jump"))
        {
            jumpTrigger = true;
            animator.SetTrigger("Jump");

        }

        crouchTrigger = Input.GetButton("Crouch");

        float dashElapsedTime = Time.time - dashTriggerTime;

        if (Input.GetButtonDown("Dash") && dashElapsedTime >= coolDown)
        {
            dashTrigger = true;
        }


    }

    private void FixedUpdate()
    {
        if (dashTrigger)
        {
            dashDirection = new Vector2(horizontalInput, verticalInput).normalized;
            controller.Dash(dashDirection);

            dashTriggerTime = Time.time;
            dashTrigger = false;

        }
        else
        {
            controller.Move(horizontalInput * Time.fixedDeltaTime, crouchTrigger, jumpTrigger);
            jumpTrigger = false;
        }

        animator.SetBool("IsGrounded", controller.grounded);
    }
}

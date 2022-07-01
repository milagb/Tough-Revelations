using System;
using UnityEngine;

public class CharacterMovement : MonoBehaviour
{
    public CharacterController2D controller;

    [SerializeField] private float coolDown = 50;

    private float horizontalInput = 0f;
    private float verticalInput;

    private float dashTriggerTime;
    private bool jump = false;
    private bool crouch = false;
    private bool dash = false;
    private Vector2 dashDirection;

    private void Start()
    {
        dashTriggerTime = -coolDown;
    }

    private void Update()
    {
        //Debug.Log("Update");
        horizontalInput = Input.GetAxisRaw("Horizontal");
        verticalInput = Input.GetAxisRaw("Vertical");

        if (Input.GetButtonDown("Jump"))
        {
            jump = true;
        }

        crouch = Input.GetButton("Crouch");

        float dashElapsedTime = Time.time - dashTriggerTime;

        if (Input.GetButtonDown("Dash") && dashElapsedTime >= coolDown)
        {
            dash = true;
        }
    }

    private void FixedUpdate()
    {
        if (dash)
        {
            dashDirection = new Vector2(horizontalInput, verticalInput).normalized;
            controller.Dash(dashDirection);

            dashTriggerTime = Time.time;
            dash = false;

        }
        else
        {
            controller.Move(horizontalInput * Time.fixedDeltaTime, crouch, jump);
            jump = false;
        }
    }
}

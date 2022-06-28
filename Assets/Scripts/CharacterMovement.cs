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
    private void Update()
    {
        horizontalMove = Input.GetAxisRaw("Horizontal") * runSpeed;
    }

    private void FixedUpdate()
    {
        controller.Move(horizontalMove * Time.fixedDeltaTime,false, false);


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

    private void OnTriggerEnter2D(Collider2D col)
    {
        throw new NotImplementedException();
    }
}

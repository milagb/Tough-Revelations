using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.Design.Serialization;
using UnityEngine;

public class CharacterMovement : MonoBehaviour
{
    private float runSpeed = 40f;
    private bool jump = false;
    private float horizontalMove = 0f;
    private float verticalMove = 0f;

    public Animator animator;

    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        horizontalMove = Input.GetAxisRaw("Horizontal") * runSpeed;


        animator.SetFloat("Speed", Mathf.Abs(horizontalMove));

        if(Input.GetMouseButtonDown(0))
        {
            jump = true;
            verticalMove = Input.GetAxisRaw("Vertical") * runSpeed;
            animator.SetBool("IsJumping", true);
        }

    }
}

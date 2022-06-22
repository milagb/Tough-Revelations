using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.Design.Serialization;
using UnityEngine;

public class CharacterMovement : MonoBehaviour
{
    [SerializeField] private float runSpeed = 5f;
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
        horizontalMove = Input.GetAxis("Horizontal") * runSpeed * Time.deltaTime;
        transform.position += new Vector3(horizontalMove, 0, 0);

        animator.SetFloat("Speed", Mathf.Abs(horizontalMove));

        if(Input.GetMouseButtonDown(0))
        {
            jump = true;
            verticalMove = Input.GetAxis("Vertical") * runSpeed;
            animator.SetBool("IsJumping", true);
        }

    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        throw new NotImplementedException();
    }
}

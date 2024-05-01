using System.Collections;
using System.Collections.Generic;
using UnityEditorInternal;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerControler : MonoBehaviour
{
    private Rigidbody2D rb;
    private bool isGrounded;
    private int jumpCounter;
    private int dashCounter;
    [SerializeField] private float movespeed;
    [SerializeField] private float jumpHeight;
    [SerializeField] private float dashSpeed;
    private Vector2 momentum;
    Vector2 speed;
    void Start()
    {
      
        rb = GetComponent<Rigidbody2D>();

    }

    // Update is called once per frame
    void Update()
    {
       
    }
    private void FixedUpdate()
    {
        
        if (isGrounded)
        {
            rb.AddForce(momentum * movespeed);
            dashCounter = 1;
            
        }

        if (rb.velocity.x >= 3.0) {
            rb.gravityScale = 0;
        }
        else
        {
            rb.gravityScale = 2;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.contacts.Length >= 1)
        {
            isGrounded = true;
            jumpCounter = 2;
            
        }
    }

    private void OnJump()
    {
        if (isGrounded || jumpCounter > 0) {
        rb.AddForce(Vector2.up * jumpHeight, ForceMode2D.Impulse);
        isGrounded = false;
        jumpCounter--;
        }
        
    }

    private void OnMovement(InputValue inputValue)
    {
        
        momentum = inputValue.Get<Vector2>();
    }

    private void OnDash(InputValue inputValue)
    {
        if(isGrounded || dashCounter > 0){
            rb.velocity = inputValue.Get<Vector2>() * dashSpeed;
            if(!isGrounded)
            {
                dashCounter--;
            }
            
        }
    }
}

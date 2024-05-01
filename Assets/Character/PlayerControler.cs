using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerControler : MonoBehaviour
{
    private Rigidbody2D rb;
    private bool isGrounded;
    private int jumpCounter;
    [SerializeField] private float movespeed;
    [SerializeField] private float jumpHeight;
    Vector2 momentum;
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
      
            rb.AddForce(momentum * movespeed);

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
        //Remember for dash
        //rb.velocity = inputValue.Get<Vector2>() * movespeed;
        momentum = inputValue.Get<Vector2>();
        






    }
}

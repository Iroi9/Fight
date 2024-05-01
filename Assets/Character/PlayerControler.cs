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
    PlayerControl inputs;
    void Start()
    {
      
        rb = GetComponent<Rigidbody2D>();
        inputs = GetComponent<PlayerControl>();
    }

    // Update is called once per frame
    void Update()
    {
     
    }

    private void OnCollisionEnter2D(UnityEngine.Collision2D collision)
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
        rb.AddForce(Vector2.up * 5, ForceMode2D.Impulse);
        isGrounded = false;
        jumpCounter--;
        }
        
    }

    private void OnMovement(InputValue inputValue)
    {
            rb.velocity = inputValue.Get<Vector2>() * movespeed;
        
        
    }
}

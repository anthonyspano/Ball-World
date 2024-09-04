using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerJump : MonoBehaviour
{
    public float jumpHeight;
    private Rigidbody rb;

    public float groundCheckRadius = 0.2f;
    public LayerMask groundLayer;
    private bool isGrounded;
    private bool doubleJumpReady;


    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        // check beneath player 
        isGrounded = Physics.CheckSphere(transform.position, groundCheckRadius, groundLayer);

        if(isGrounded)
            doubleJumpReady = true;

        // Jump logic
        if (isGrounded && Input.GetKeyDown(KeyCode.Space))
        {
            rb.AddForce(new Vector3(0, 0, 1) * jumpHeight, ForceMode.Impulse);
        }
        else if(doubleJumpReady && Input.GetKeyDown(KeyCode.Space))
        {
            rb.AddForce(new Vector3(0, 0, 1) * jumpHeight, ForceMode.Impulse);
            doubleJumpReady = false;
        }
        
    }
}

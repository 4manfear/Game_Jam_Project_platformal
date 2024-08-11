using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class threed_Player_Movement : MonoBehaviour
{
   
    private float movespeed;
    [SerializeField]
    private float walkspeed;
    [SerializeField]
    private float runspeed;
    [SerializeField]
    private float mouseSensitivity;

    float horizontalinput;
    float verticalinput;

    private float xRotation;

    private Rigidbody rb;


    [SerializeField]
    private float jumpForce = 5f; // Force applied for jumping
    [SerializeField]
    private LayerMask groundLayer;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }
    private void Start()
    {
        movespeed = walkspeed;
    }

    private void FixedUpdate()
    {
        

        horizontalinput = Input.GetAxisRaw("Horizontal");
        verticalinput = Input.GetAxisRaw("Vertical");


        Vector3 movement = new Vector3(horizontalinput, 0, verticalinput).normalized;

        // Calculate the velocity based on the movement vector and speed
        Vector3 velocity = transform.TransformDirection(movement) * movespeed;

        // Apply the velocity to the Rigidbody
        rb.velocity = new Vector3(velocity.x, rb.velocity.y, velocity.z);

    }

    private void Update()
    {
        HandleJump();
    }
    private void HandleMovement()
    {
        horizontalinput = Input.GetAxisRaw("Horizontal");
        verticalinput = Input.GetAxisRaw("Vertical");

        Vector3 movement = new Vector3(horizontalinput, 0, verticalinput).normalized;

        // Calculate the velocity based on the movement vector and speed
        Vector3 velocity = transform.TransformDirection(movement) * movespeed;

        // Apply the velocity to the Rigidbody
        rb.velocity = new Vector3(velocity.x, rb.velocity.y, velocity.z);
    }

    private void HandleJump()
    {
        if (IsGrounded() && Input.GetButtonDown("Jump"))
        {
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
        }
    }

    private bool IsGrounded()
    {
        // Raycast down from the player's position to check if they are on the ground
        float rayLength = 1.1f; // Slightly more than the player’s height to ensure ground detection
        return Physics.Raycast(transform.position, Vector3.down, rayLength, groundLayer);
    }


}

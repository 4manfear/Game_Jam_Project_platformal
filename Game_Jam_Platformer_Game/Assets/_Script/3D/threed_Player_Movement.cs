using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.SceneManagement;

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

    private AudioSource audioSource;


    [SerializeField]
    private float jumpForce = 5f; // Force applied for jumping
    [SerializeField]
    private LayerMask groundLayer;
    public bool _is2Denabled;
    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
        audioSource = GetComponent<AudioSource>();
    }
    private void Start()
    {
        movespeed = walkspeed;
    }

    private void FixedUpdate()
    {
        if (!_is2Denabled)
        {
            HandleMovement();
        }

        
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

        // Check if the player is moving
        if (movement.magnitude > 0 && !audioSource.isPlaying)
        {
            audioSource.Play(); // Start playing the audio if the player is moving and the audio is not already playing
        }
        else if (movement.magnitude == 0 && audioSource.isPlaying)
        {
            audioSource.Stop(); // Stop the audio if the player is not moving
        }
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

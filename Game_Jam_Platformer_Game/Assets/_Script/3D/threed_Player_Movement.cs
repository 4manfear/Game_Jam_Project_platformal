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

}

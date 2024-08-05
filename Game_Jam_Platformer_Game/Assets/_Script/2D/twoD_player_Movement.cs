using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class twoD_player_Movement : MonoBehaviour
{
    [SerializeField]
    private float movespeed;
    [SerializeField]
    private float Gravitymultiplyer;
    [SerializeField]
    private float jumpforce;

    public bool isjumping;

    Rigidbody rb;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void FixedUpdate()
    {
        // Read input from the horizontal axis (X) and fixed vertical movement (Z)
        float moveHorizontal = Input.GetAxis("Horizontal");
        

        // Create a movement vector based on input
        Vector3 movement = new Vector3(moveHorizontal, 0.0f, 0.0f);

        // Apply additional gravity manually
        rb.AddForce(Vector3.down * (Gravitymultiplyer * 60), ForceMode.Acceleration);

        // Move the Rigidbody by setting its velocity
        rb.velocity = movement * movespeed;

        // Ensure the player is always facing the positive Z direction
        if (movement != Vector3.zero)
        {
            Quaternion targetRotation = Quaternion.LookRotation(Vector3.forward);
            transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, Time.deltaTime * movespeed);
        }

        // Rotate the player based on movement direction
        if (moveHorizontal > 0.0f)
        {
            transform.localRotation = Quaternion.Euler(0, 0, 0);
        }
        else if (moveHorizontal < 0.0f)
        {
            transform.localRotation = Quaternion.Euler(0, 180, 0); 
        }
        if(isjumping)
        {
            rb.AddForce(transform.up * jumpforce, ForceMode.Impulse);
        }
        
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            isjumping = true;
            Debug.Log("pressed");
            //jumping();
        }
        else
        {
            isjumping = false;
            Debug.Log("Realised");
        }
    }

    //void jumping()
    //{
    //   
    //}

}

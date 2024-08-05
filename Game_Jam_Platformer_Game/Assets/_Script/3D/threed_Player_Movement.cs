using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class threed_Player_Movement : MonoBehaviour
{
    private float moveSpeed ; // Speed of movement
    [SerializeField]
    private float rotationspeed;
    [SerializeField]
    private float walkspeed;

    [SerializeField]
    private Camera threedcamera;

    private Rigidbody rb; // Reference to the Rigidbody component

    private void Start()
    {
        // Get the Rigidbody component attached to the same GameObject
        rb = GetComponent<Rigidbody>();
        moveSpeed = walkspeed;
    }

   
    private void FixedUpdate()
    {
        // Read input from the horizontal and vertical axes
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        // Create a local movement vector based on input
        Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical);

        //taking forword and right of the camera
        Vector3 camfroword = threedcamera.transform.forward;
        Vector3 camright = threedcamera.transform.right;

        camfroword.y = 0f;
        camright.y = 0f;

        // Calculate the direction relative to the camera
        Vector3 directionofcame = camfroword * movement.z + camright * movement.x;

        Vector3 normalizedDirection = directionofcame.normalized;

        // Move the Rigidbody by setting its velocity
        rb.velocity = directionofcame.normalized * moveSpeed;

        if (directionofcame != Vector3.zero)
        {
            Quaternion targetrotation = Quaternion.LookRotation(normalizedDirection);
            transform.rotation = Quaternion.Slerp(transform.rotation, targetrotation,   Time.fixedDeltaTime*rotationspeed );
        }
    }
}

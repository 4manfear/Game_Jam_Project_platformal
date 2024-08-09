using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FPP_Camera : MonoBehaviour
{
    [SerializeField]
    private Transform playerBody; 

    [SerializeField]
    private float mouseSensitivity = 100f; 

    private float xRotation = 0f; 

    private void Start()
    {
        
        Cursor.lockState = CursorLockMode.Locked;
    }

    private void Update()
    {
        // Reading the mouse input
        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime;

        // Adjust the vertical rotation based on mouse input and clamp it
        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, -90f, 90f); // Limit vertical look to 90 degrees up and down

        // Rotate the camera around the X-axis
        transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);

        // Rotate the player body around the Y-axis
        playerBody.Rotate(Vector3.up * mouseX);
    }
}

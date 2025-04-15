using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float speed = 5f;            // Movement speed
    public float rotationSpeed = 700f;  // Rotation speed
    public float gravity = -9.8f;      // Gravity force
    public float jumpHeight = 2f;      // Jump height

    private CharacterController controller;
    public Vector3 velocity;
    private float yRotation = 0f;      // Store the current y-rotation of the camera
    private Transform playerCamera;
    public bool isGrounded;

    void Start()
    {
        // Get the CharacterController component attached to the GameObject
        controller = GetComponent<CharacterController>();

        // Get the camera transform to help with player rotation
        playerCamera = Camera.main.transform;
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;

    }

    void Update()
    {
        isGrounded = controller.isGrounded; // Check if the player is grounded

        MovePlayer();
        ApplyGravity();
        Jump();
        RotatePlayer();
    }

    void MovePlayer()
    {
        // Get input from horizontal (A/D or Left/Right arrow) and vertical (W/S or Up/Down arrow) axes
        float moveX = Input.GetAxis("Horizontal");
        float moveZ = Input.GetAxis("Vertical");

        // Calculate movement direction based on the camera's orientation
        Vector3 move = transform.right * moveX + transform.forward * moveZ;

        // Apply the movement with the speed factor
        controller.Move(move * speed * Time.deltaTime);
    }

    void RotatePlayer()
    {
        // Rotate the player horizontally with mouse input (looking around)
        float horizontal = Input.GetAxis("Mouse X");
        transform.Rotate(0, horizontal * rotationSpeed * Time.deltaTime, 0);

        // Rotate the camera vertically with mouse input (looking up and down)
        float vertical = Input.GetAxis("Mouse Y");
        yRotation -= vertical * rotationSpeed * Time.deltaTime;
        yRotation = Mathf.Clamp(yRotation, -80f, 80f);  // Limit the camera vertical rotation
        playerCamera.localRotation = Quaternion.Euler(yRotation, 0, 0);
    }

   public void Jump()
    {
        // If the player is grounded and presses the jump button (spacebar)
        if (isGrounded && Input.GetButtonDown("Jump"))
        {
            // Apply an upward force (jump)
            velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity);
        }
    }

    void ApplyGravity()
    {
        // Apply gravity to the player if not grounded
        if (isGrounded && velocity.y < 0)
        {
            velocity.y = -2f; // Keep the player grounded (small negative value)
        }
        else
        {
            velocity.y += gravity * Time.deltaTime; // Apply gravity when in the air
        }

        // Move the player based on the velocity
        controller.Move(velocity * Time.deltaTime);
    }
}
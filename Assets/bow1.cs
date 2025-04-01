using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bow1 : MonoBehaviour
{
    public GameObject[] bullet;
    public Transform player;
    public Transform playerCamera; // Reference to the camera transform
    public GameObject pullet;
    public float numberbow1z = 0;
    public float numberbow1y = 0;

    void Start()
    {
    }

    void Update()
    {
        if (Input.GetButtonDown("atack"))
        {
            for (int a = 0; a < bullet.Length; a++)
            {
                numberbow1z = Random.Range(0.5f, 1f);
                numberbow1y = Random.Range(0.1f, 0.5f);

                // Use the camera's forward direction for aiming
                Vector3 shootDirection = playerCamera.forward;
                
                // Instantiate bullet at player position, following their camera's forward direction
                GameObject newBullet = Instantiate(pullet, player.position + shootDirection * 0.1f + new Vector3(numberbow1z, numberbow1y, 0), playerCamera.rotation);
                
                // Apply force to move bullet in the direction the camera is facing
                Rigidbody rb = newBullet.GetComponent<Rigidbody>();
                if (rb != null)
                {
                    rb.velocity = shootDirection * 10f; // Adjust speed as needed
                }
            }
        }
    }
}
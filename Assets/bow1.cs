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
    private Bulletscript speed;
    public float durability = 10;
    public currentweapons playerscript;
    public GameObject prefab;

    void Start()
    {
      
    }

    void Update()
    {Vector3 shootDirection = playerCamera.forward;
       
        if (Input.GetButtonDown("atack"))
        {
            for (int a = 0; a < bullet.Length; a++)
            {
                numberbow1z = Random.Range(0.5f, 1f);
                numberbow1y = Random.Range(0.1f, 0.5f);
                    
             Quaternion randomOffset = Quaternion.Euler( Random.Range(-10f, 10f),Random.Range(-10f, 10f), 0f );

        Quaternion randomRotation = playerCamera.rotation * randomOffset;

        // Example: Apply the random rotation to this object
        
                
                
                // Use the camera's forward direction for aiming
                
                
                // Instantiate bullet at player position, following their camera's forward direction
                GameObject newBullet = Instantiate(pullet, player.position + shootDirection * 0.1f + new Vector3(numberbow1z, numberbow1y, 0),  Quaternion.LookRotation(playerCamera.forward));
                
                
                // Apply force to move bullet in the direction the camera is facing
                Rigidbody rb = newBullet.GetComponent<Rigidbody>();
                speed=newBullet.GetComponent<Bulletscript>();
                if (rb != null)
                {
                    rb.velocity = shootDirection * speed.bulletspeed; // Adjust speed as needed
                }
            }
            durability = durability - 1;
            if(durability==0)
            {   
                  playerscript = GameObject.Find("Player").GetComponent<currentweapons>();
                 playerscript.currentweap.RemoveAt(playerscript.currentequip)    ;
                 Destroy(gameObject);
                 playerscript.currentlyequipped = playerscript.currentlyequipped-1;
           
                 
            }
        }
    }
    public void destr()
    {
        Destroy(gameObject);
    }
}
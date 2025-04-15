using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class feather : MonoBehaviour
{private Vector3 featherj;
private CharacterController controller;
private float ja = 0;
public Transform player;
public float happened;
private PlayerMovement moveme;
private currentweapons playerscript;

    // Start is called before the first frame update
    void Start()
    {
       controller = GameObject.Find("Player").GetComponent<CharacterController>();
       moveme= GameObject.Find("Player").GetComponent<PlayerMovement>();
    }

    // Update is called once per frame
    void Update()
    {
       
        
        if (Input.GetButtonDown("atack"))
        {  if(ja==0)
        {
            moveme.velocity.y = Mathf.Sqrt(moveme.jumpHeight *-2f * moveme.gravity*1);
        happened=happened+1;
        moveme.speed = 10f;
        }
          
        // Move the player based on the velocity
       

        
        

    
}
if(moveme.isGrounded && moveme.speed != 5f)
{
    moveme.speed = 5f;
}
if(happened==10)
    {
       ja = 1f;
       if(moveme.isGrounded) 
       {
playerscript = GameObject.Find("Player").GetComponent<currentweapons>();
                 playerscript.currentweap.RemoveAt(playerscript.currentlyequipped)    ;
                 playerscript.currentlyequipped = playerscript.currentlyequipped-1;
                 Destroy(gameObject);
                 
       }
       
    }
}
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class itemrelated : MonoBehaviour
{
    public GameObject Itemrelated;
    public currentweapons player;

    // Start is called before the first frame update
    void Start()
    {
        // Ensure player is found early (caching player reference)
        player = GameObject.Find("Player").GetComponent<currentweapons>();
        if (player == null)
        {
            Debug.LogError("Player not found, ensure the Player GameObject is named 'Player' and has currentweapons script attached.");
        }
    }

    // Update is called once per frame
    void Update()
    {
     
    }

    private void OnCollisionEnter(Collision collision)
    
    {
        if (collision.gameObject.tag == "turnableitem") // Checking for collision with the player
        {
           
            
                        Destroy(collision.gameObject);
                        player.currentweap.Add(Itemrelated);
                        Destroy(gameObject);
                       
                    }
    }
            
                    
       
}


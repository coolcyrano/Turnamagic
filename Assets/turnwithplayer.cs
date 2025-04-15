using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class turnwithplayer : MonoBehaviour
{
    public Transform player; // Player reference (found at runtime)

 

    void Update()
    {
        
            transform.rotation = player.rotation; // Weapon follows Player's rotation
     }
  }

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyatks : MonoBehaviour
{private currentweapons hpofplayer;
public float Damage=25f;


    // Start is called before the first frame update
    void Start()
    {
      hpofplayer=GameObject.Find("player").GetComponent<currentweapons>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
     private void OnCollisionEnter(Collision collision)
     {if(collision.gameObject.tag=="Player")
        {
            hpofplayer.TakeDamage(Damage);
        }
}
}

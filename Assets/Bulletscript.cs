using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bulletscript : MonoBehaviour
{Vector3 hayvector;
public float bulletspeed= 1f;
Rigidbody bulletrig;
private  Dummy dummy;
private Enemyscript enemy;
public float bulletdamage = 1;
    // Start is called before the first frame update
    void Start()
    {
            bulletrig = GetComponent<Rigidbody>();
            
            hayvector = transform.forward * bulletspeed;
            bulletrig.velocity = hayvector;
            dummy=GameObject.Find("dummy").GetComponent<Dummy>();
             bulletrig.velocity = transform.forward * bulletspeed;
         
    }

    // Update is called once per frame
    void Update()
    {
       
        
    }
     private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag!="Player")
        {if(collision.gameObject.tag=="dummy")
        {
            dummy.TakeDamage(bulletdamage);
        }
            Destroy(gameObject);
        }
        if(collision.gameObject.tag=="Player")
        {
            Destroy(gameObject);
        }
        if(collision.gameObject.tag=="Enemy")
        {
            enemy = collision.gameObject.GetComponent<Enemyscript>();
            enemy.hp = enemy.hp - bulletdamage;
            
        }
}
}

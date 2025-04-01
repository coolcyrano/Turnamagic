using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bulletscript : MonoBehaviour
{Vector3 hayvector;
public float bulletspeed= 1f;
Rigidbody bulletrig;
private  Dummy enemy;
    // Start is called before the first frame update
    void Start()
    {
            bulletrig = GetComponent<Rigidbody>();
            hayvector=new Vector3(Random.Range(100f,500f)*bulletspeed*Time.deltaTime,0.01f,0f);
            hayvector = transform.forward * bulletspeed;
            bulletrig.velocity = hayvector;
            enemy=GameObject.Find("Sphere").GetComponent<Dummy>();
    }

    // Update is called once per frame
    void Update()
    {
       
         bulletrig.velocity = transform.forward * bulletspeed;
         
    }
     private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag!="Player")
        {if(collision.gameObject.tag=="Enemy")
        {
            enemy.TakeDamage(1);
        }
            Destroy(gameObject);
        }
}
}

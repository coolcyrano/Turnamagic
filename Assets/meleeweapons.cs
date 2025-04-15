using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class meleeweapons : MonoBehaviour
{ public Transform weapon;
public Vector3 targetpos;
public float speed= 0.002f;
public float damage = 1;
private  Dummy dummy;
private Enemyscript enemy;
public float durability = 19;
private Animator animator;
public Transform camera;
    // Start is called before the first frame update
    void Start()
    {
         dummy=GameObject.Find("dummy").GetComponent<Dummy>();
         weapon.position = weapon.position + new Vector3(0.4f, -3, 0.2f);
         animator = GetComponent<Animator>();
       
         
            
    }

    // Update is called once per frame
    void Update()
    {weapon.rotation = camera.rotation;
        if (Input.GetButtonDown("atack"))
        {
             animator.Play("Base Layer.stickanimation", 0, 0);
        
        }
    }
      private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag!="Player")
        {if(collision.gameObject.tag=="dummy")
        {
            dummy.TakeDamage(damage);
        }
        }
    
        if(collision.gameObject.tag=="Enemy")
        {
            enemy = collision.gameObject.GetComponent<Enemyscript>();
            enemy.hp = enemy.hp - damage;
            durability = durability -1;
            
        }
}
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class currentweapons : MonoBehaviour
{ 
    public List<GameObject> currentweap = new List<GameObject>();  
    public Transform placeforweap;
    public int currentlyequipped = 0;
    public int currentequip= -1; // Index starts at 0
    public GameObject currentlyEquippedWeapon; // Stores the active weapon instance
    public GameObject magicbull;
    public Transform camera;
    public float hp = 100;


    // Start is called before the first frame update
    void Start()
    {
        currentlyEquippedWeapon = Instantiate(currentweap[0], placeforweap.position, placeforweap.rotation);
currentlyEquippedWeapon.transform.SetParent(camera);

    }

    // Update is called once per frame
    void Update()
    {
          { if (Input.GetButtonDown("turnmagic"))
       {
        Vector3 shootDirection = camera.forward;
        Instantiate(magicbull,placeforweap.position + shootDirection * 0.1f + new Vector3(0, 0, 2),placeforweap.rotation);
       }
        if (Input.GetButtonDown("cycle"))
        {  
            if (currentweap.Count > 0) // Ensure the list isn't empty
            { if(currentlyequipped==currentweap.Count-1)
        {
            currentlyequipped =0;
        }
          GameObject oldWeaponInstance = currentlyEquippedWeapon; // Store the instance of the currently equipped weapon

// Instantiate the new weapon
GameObject newWeapon = Instantiate(currentweap[currentlyequipped + 1], placeforweap.position, Quaternion.identity);
newWeapon.transform.SetParent(camera); // Attach to the weapon holder

// Update the reference to the currently equipped weapon
currentlyEquippedWeapon = newWeapon;

// Destroy the old weapon instance (not the prefab!)
if (oldWeaponInstance != null)
{
    Destroy(oldWeaponInstance);
}

// Update the currently equipped index
currentlyequipped = currentlyequipped + 1;
currentequip = currentlyequipped;
               
             
             
            }
        }
    }

}
       public void TakeDamage(float damage)
    {
        hp = hp-damage;
        
    }
}
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryManager : MonoBehaviour
{ public GameObject inventoryMenu;
private bool menuActivated;
public ItemSlot[] itemSlot;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetButtonDown("inventory")&& menuActivated)
        {
           inventoryMenu.SetActive(false);
           menuActivated = false;
        }
      else if(Input.GetButtonDown("inventory")&& !menuActivated)
        {
           inventoryMenu.SetActive(true);
           menuActivated = true;
        }  
}
public void AddItem(string itemName, int quantity , Sprite itemSprite)
{
   Debug.Log("itemname =" + itemName + quantity + itemSprite);
   for(int i = 0; i < itemSlot.Length; i++)
   {
      if(itemSlot[i].isFull==false)
      {
         itemSlot[i].AddItem(itemName,quantity ,itemSprite);
         return;
      }
   }

}
}

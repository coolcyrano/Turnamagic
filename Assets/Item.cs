using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour
{[SerializeField]
private string itemName;
[SerializeField]
private int quantity;
[SerializeField]
private Sprite itemSprite;
private InventoryManager inventoryManager;
    // Start is called before the first frame update
    void Start()
    {
        inventoryManager= GameObject.Find("inventory").GetComponent<InventoryManager>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag=="Player")
        {
            inventoryManager.AddItem(itemName, quantity, itemSprite	);
            Destroy(gameObject);
        }
    }
    }

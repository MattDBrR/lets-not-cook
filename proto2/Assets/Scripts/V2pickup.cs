using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class ItemPickup : MonoBehaviour
{
    public Item item; // Assign your item in the Inspector

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("collider triggered");
        if (other.CompareTag("Player"))
        {
            V2Inventory inventory = other.GetComponent<V2Inventory>();
            if (inventory != null)
            {
                inventory.AddItem(item);
                Debug.Log($"{item.itemName} has been added to inventory.");
                Destroy(gameObject);
            }
        }
    }
}

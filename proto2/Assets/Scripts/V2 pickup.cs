using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class V2pickup : MonoBehaviour
{
    public Item item; // Assign your item in the Inspector

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player")) // Ensure the Player has the tag "Player"
        {
            Inventory2 inventory = other.GetComponent<Inventory2>();
            if (inventory != null)
            {
                inventory.AddItem(item);
                Debug.Log($"{item.itemName} has been added to inventory.");
                Destroy(gameObject); // Remove the box after pickup
            }
        }
    }
}

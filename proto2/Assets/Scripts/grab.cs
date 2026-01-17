"""
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grabbable : MonoBehaviour
{
    public bool isGrabbable = true;
    public float grabRange = 2.0f;
    private bool isInRange = false;
    private KeyboardControlMaster nearbyPlayer;
    private Rigidbody rb;
    private bool wasKinematic = false;

    // Store item data for inventory
    public string itemName;
    public Sprite itemIcon;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        if (string.IsNullOrEmpty(itemName))
        {
            itemName = gameObject.name;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            KeyboardControlMaster player = other.GetComponent<KeyboardControlMaster>();
            if (player != null)
            {
                isInRange = true;
                nearbyPlayer = player;
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            KeyboardControlMaster player = other.GetComponent<KeyboardControlMaster>();
            if (player == nearbyPlayer)
            {
                isInRange = false;
                nearbyPlayer = null;
            }
        }
    }

    public void Grab(Inventory playerInventory)
    {
        if (!isGrabbable || playerInventory == null) return;

        // Create a copy of the item data
        InventoryItem itemData = new InventoryItem
        {
            itemName = this.itemName,
            itemIcon = this.itemIcon,
            originalPrefab = gameObject
        };

        // Try to add to inventory
        if (playerInventory.AddItem(itemData))
        {
            // Delete this instance
            Destroy(gameObject);
        }
    }

    public void Release(Vector3 releasePosition, GameObject prefab)
    {
        // Instantiate a new instance at the release position
        Instantiate(prefab, releasePosition, Quaternion.identity);
    }

    public bool IsInRange()
    {
        return isInRange;
    }

    public KeyboardControlMaster GetNearbyPlayer()
    {
        return nearbyPlayer;
    }
}

// Data structure to store item info in inventory
[System.Serializable]
public class InventoryItem
{
    public string itemName;
    public Sprite itemIcon;
    public GameObject originalPrefab;
}
"""


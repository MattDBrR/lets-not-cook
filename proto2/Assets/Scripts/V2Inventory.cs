using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Item
{
    public string itemName;
}

public class V2Inventory : MonoBehaviour
{
    public List<Item> items = new List<Item>();
    public int numberOfSlots = 5;

    public void AddItem(Item item)
    {
        if (!IsFull())
        {
            items.Add(item);
            Debug.Log("Item added: " + item.itemName);
        }
    }

    public Item RemoveItem()
    {
        if (items.Count > 0)
        {
            Item item = items[items.Count - 1];
            items.RemoveAt(items.Count - 1);
            Debug.Log("Item removed: " + item.itemName);
            return item;
        }
        return null;
    }
    

    public bool IsFull()
    {
        return items.Count >= numberOfSlots;
    }

    public bool IsEmpty()
    {
        return items.Count == 0;
    }
}

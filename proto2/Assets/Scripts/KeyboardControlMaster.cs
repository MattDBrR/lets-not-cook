using System;
using UnityEngine;


public class KeyboardControlMaster : MonoBehaviour
{
    public float speed = 0.1F;
    public bool isPlayer1; // player 1 (Arrow keys), player 2 (ZQSD)
    private V2Inventory inventory;

    /*
    void Start()
    {
        Debug.Log("Init " + gameObject.name);
        inventory = GetComponent<V2Inventory>();
        if (inventory == null)
        {
            Debug.LogError("Pas d'inventaire sur " + gameObject.name);
        }
    }
    */

    void FixedUpdate()
    {
        // Move based on player input
        if (isPlayer1)
        {
            MovePlayer1(); 
        }
        else
        {
            MovePlayer2();
        }
    }

    private void MovePlayer1()
    {
        // Player 1 control - Arrow keys
        float h = Input.GetKey(KeyCode.LeftArrow) ? -1 : (Input.GetKey(KeyCode.RightArrow) ? 1 : 0);
        float v = Input.GetKey(KeyCode.UpArrow) ? 1 : (Input.GetKey(KeyCode.DownArrow) ? -1 : 0);

        UpdatePositionAndRotation(h, v);
    }

    private void MovePlayer2()
    {
        // Player 2 control - ZQSD
        float h = Input.GetKey(KeyCode.A) ? -1 : (Input.GetKey(KeyCode.D) ? 1 : 0);
        float v = Input.GetKey(KeyCode.W) ? 1 : (Input.GetKey(KeyCode.S) ? -1 : 0);

        UpdatePositionAndRotation(h, v);
    }

    private void UpdatePositionAndRotation(float h, float v)
    {
        // Update object position
        transform.position += new Vector3(h, 0.0F, v).normalized * speed;

        // Update object rotation
        if (Mathf.Abs(h) < 0.01F && Mathf.Abs(v) < 0.01F) { return; }
        gameObject.transform.rotation = Quaternion.LookRotation(new Vector3(h, 0.0F, v));
    }
}
/*
    void Update()
    {
        HandleInput();
    }


}

    private void HandleInput()
    {
        // Grab input - Player 1 uses RightShift, Player 2 uses E
        if (isPlayer1 && Input.GetKeyDown(KeyCode.RightShift))
        {
            AttemptGrab();
        }
        else if (!isPlayer1 && Input.GetKeyDown(KeyCode.E))
        {
            AttemptGrab();
        }

        // Release logic - both players use Space
        if (Input.GetKeyDown(KeyCode.Space))
        {
            ReleaseItem();
        }
    }

    private void AttemptGrab()
    {
        if (inventory == null || inventory.IsFull()) return;

        // Find nearby grabbable objects
        Collider[] hits = Physics.OverlapSphere(transform.position, 2.0f);
        foreach (var hit in hits)
        {
            InventoryGrab grabbable = hit.GetComponent<InventoryGrab>();
            if (grabbable != null && grabbable.IsInRange())
            {
                grabbable.Grab(inventory);
                return; // Only grab one object
            }
        }
    }

    private void ReleaseItem()
    {
        if (inventory == null || inventory.IsEmpty()) return;

        InventoryItem item = inventory.RemoveItem();
    }
}
*/
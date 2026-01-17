using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class keyboardtarget : MonoBehaviour
{

    public float speed = 0.1F;
    public bool isPlayer1; // player 1 (Arrow keys), player 2 (ZQSD)
    private Vector3 lastValidPosition; //store previous position
    public float yLimit = 5.0f; // Example boundary limit on the y-axis

    
    // bounds
    private float minX = -2.22f;
    private float maxX = 2.175f;
    private float minZ = -5.77f;
    private float maxZ = 5.32f;
    


    // Start is called before the first frame update
    void Start()
    {

        Debug.Log("Init arrow " + gameObject.name);
        // create a target that follows keyboard input
        
        lastValidPosition = transform.position;

    }

    void FixedUpdate()
    {
        // Move based on player input
        if (isPlayer1)
        {
            Arrow1(); 
        }
        else
        {
            Arrow2();
        }
    }

    private void Arrow1()
    {
        // Player 1 control - Arrow keys
        float h = Input.GetKey(KeyCode.LeftArrow) ? -1 : (Input.GetKey(KeyCode.RightArrow) ? 1 : 0);
        float v = Input.GetKey(KeyCode.UpArrow) ? 1 : (Input.GetKey(KeyCode.DownArrow) ? -1 : 0);

        UpdatePositionAndRotation(h, v);
    }

    private void Arrow2()
    {
        // Player 2 control - ZQSD
        float h = Input.GetKey(KeyCode.A) ? -1 : (Input.GetKey(KeyCode.D) ? 1 : 0);
        float v = Input.GetKey(KeyCode.W) ? 1 : (Input.GetKey(KeyCode.S) ? -1 : 0);

        UpdatePositionAndRotation(h, v);
    }

    private void UpdatePositionAndRotation(float h, float v)
    {
        Vector3 newPos = transform.position + new Vector3(h, 0.0F, v).normalized * speed;        // Update object position

            // Check if boundary
            if (newPos.x < minX || newPos.x > maxX || newPos.z < minZ || newPos.z > maxZ)
            {
                // Revert to last valid position
                transform.position = lastValidPosition;
                return;
            }

        transform.position = newPos;
        lastValidPosition = transform.position; // Update last valid position

        // Update object rotation
        if (Mathf.Abs(h) < 0.01F && Mathf.Abs(v) < 0.01F) { return; }
        gameObject.transform.rotation = Quaternion.LookRotation(new Vector3(h, 0.0F, v));
    }
}

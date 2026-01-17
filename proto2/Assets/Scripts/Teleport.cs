using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teleport : MonoBehaviour
{
    public Vector3 initialPosition;
    
    // Start is called before the first frame update
    void Start()
    {
        // teleport owner at initialPosition upon startup
        transform.position = initialPosition;
    }

}

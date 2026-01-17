using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectSpawner : MonoBehaviour
{
    public GameObject objectToSpawn;
    public Transform player1; // Reference to Player 1
    public Transform player2; // Reference to Player 2


    private bool IsPlayerCloseToSpawner(Transform player)
    {
        return Vector3.Distance(transform.position, player.position) <= spawnDistance;
    }


    private bool inSpawnerRange(Transform drone, Transform drone Variant)
{
    // Check if player1 has KeyboardControlMaster and isPlayer1 is true
    if (player1.TryGetComponent<KeyboardControlMaster>(out var player1Control) && player1Control.isPlayer1)
    {
        if (Vector3.Distance(transform.position, drone.position) <= spawnDistance)
        {
            return true; // Player 1 is close to the spawner
        }
    }


    void Update()
    {   if (Transform player1)
            if (Input.GetKeyDown(KeyCode.RightShift)) // Player 1 Spawn
            {
                SpawnObject(player1);
            }

            if (Input.GetKeyDown(KeyCode.A)) // Player 2 Spawn
            {
                SpawnObject(player2);
            }
    }

    void SpawnObject(Transform player)
    {
            GameObject spawnedObject = Instantiate(objectToSpawn, player.position, Quaternion.identity);
            spawnedObject.GetComponent<grabbable>().Grab(player); // Grab immediately to position
    }
}
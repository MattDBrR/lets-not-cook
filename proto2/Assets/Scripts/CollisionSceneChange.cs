using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CollisionSceneChange : MonoBehaviour
{
    // This method is called when a collider enters the trigger
    void OnCollisionEnter(Collision collision)
    {
        // Check for the specific object that triggers the scene change
        if (collision.gameObject.CompareTag("Player"))  // Assuming the colliding object has the tag "Player"
        {
            ChangeScene("Main"); // Replace with your target scene name
        }
    }

    void ChangeScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);  // Load the specified scene
    }
}

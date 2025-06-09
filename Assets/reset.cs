using UnityEngine;
using UnityEngine.SceneManagement;

public class reset : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        // Check if the entering object has the "PlayerBody" tag
        if (other.CompareTag("PlayerBody"))
        {
            // Reset the current scene
            Scene currentScene = SceneManager.GetActiveScene();
            SceneManager.LoadScene(currentScene.name);
        }
    }
}

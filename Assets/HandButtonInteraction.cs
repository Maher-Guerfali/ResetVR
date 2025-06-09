using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class HandButtonInteraction : MonoBehaviour
{
    public int gameplaySceneIndex = 1; // Enter the index of your gameplay scene in the Inspector
    public GameObject loadingScreen;
    public Slider loadingSlider;

    private bool isHandInRange = false;
    private bool isSceneLoaded = false; // Flag to track if the scene has been loaded

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Hand"))
        {
            isHandInRange = true;

            // Start loading the scene when hand collides with the button
            StartGame();
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Hand"))
        {
            isHandInRange = false;
        }
    }

    public void StartGame()
    {
        if (isHandInRange && !isSceneLoaded)
        {
            // Show the loading screen
            loadingScreen.SetActive(true);

            // Start the asynchronous loading of the gameplay scene
            StartCoroutine(LoadGameplaySceneAsync());
        }
    }

    private IEnumerator LoadGameplaySceneAsync()
    {
        // Set the flag to prevent loading the scene multiple times
        isSceneLoaded = true;

        // Create an AsyncOperation object to load the scene
        AsyncOperation asyncLoad = SceneManager.LoadSceneAsync(gameplaySceneIndex);

        // Disable scene activation so it doesn't automatically switch when loaded
        asyncLoad.allowSceneActivation = false;

        // Update the loading slider progress while the scene is loading
        while (!asyncLoad.isDone)
        {
            loadingSlider.value = asyncLoad.progress;

            // Check if the scene is fully loaded
            if (asyncLoad.progress >= 0.9f)
            {
                // The scene is almost loaded, set the slider to full value (progress: 0 to 1)
                loadingSlider.value = 1f;

                // Allow scene activation to switch to the loaded scene
                asyncLoad.allowSceneActivation = true;
            }

            yield return null;
        }
    }
}

using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;


public class LoadingScreen : MonoBehaviour
{
    public int gameSceneBuildIndex; // The build index of the game scene you want to load.

    private void Start()
    {
        // Start loading the game scene asynchronously.
        StartCoroutine(LoadGameSceneAsync());
    }

    private IEnumerator LoadGameSceneAsync()
    {
        // Show the loading screen.

        yield return null; // Wait for one frame to allow the UI to update.

        // Start loading the game scene asynchronously using the build index.
        AsyncOperation asyncLoad = SceneManager.LoadSceneAsync(gameSceneBuildIndex);

        // While the game scene is loading, update the progress bar or any other loading indicator.
        while (!asyncLoad.isDone)
        {
            // Update the progress bar based on asyncLoad.progress (ranges from 0 to 1).
            // You can also use this value to update loading text, etc.

            yield return null;
        }

        // The game scene has finished loading. You can do any post-loading setup here.
    }
}

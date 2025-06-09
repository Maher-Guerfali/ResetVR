using UnityEngine;

public class GameFreezeToggle : MonoBehaviour
{
    private bool isGameFrozen = false;

  

    public void ToggleGameFreeze()
    {
        isGameFrozen = !isGameFrozen;

        if (isGameFrozen)
        {
            // Freeze the game
            Time.timeScale = 0f;
            Debug.Log("Game is frozen");
        }
        else
        {
            // Unfreeze the game
            Time.timeScale = 1f;
            Debug.Log("Game is unfrozen");
        }
    }
}

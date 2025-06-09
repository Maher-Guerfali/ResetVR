using UnityEngine;
using UnityEngine.UI;

public class EnemyCounter : MonoBehaviour
{
    public Text counterText; // Reference to the UI Text object for displaying the counter
    private int enemyCount = 0; // Counter for the number of enemies killed
    private void Update()
    {
        //counterText.text = EnemySpawner.Instance.counterkills.ToString() ;
    }
    // Call this method whenever an enemy is killed
    public void EnemyKilled()
    {
        enemyCount++;
        UpdateCounterText();
    }

    // Update the UI text with the current enemy count
    private void UpdateCounterText()
    {
        counterText.text = "Enemy Killed: " + enemyCount.ToString();
    }
}

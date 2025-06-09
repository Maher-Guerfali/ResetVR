using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    public float totalTime = 60f; // Total time for the timer
    public Text timerText; // Reference to the UI Text object

    private float currentTime; // Current time of the timer

    private void Start()
    {
        currentTime = totalTime; // Set the current time to the total time at the start
    }

    private void Update()
    {
        // Update the timer
        currentTime -= Time.deltaTime;

        // Check if the timer has reached zero
        if (currentTime <= 0f)
        {
            currentTime = 0f; // Clamp the current time to zero
            // Handle timer completion or any other desired action
        }

        // Update the UI text with the timer value
        timerText.text = "Timer: " + currentTime.ToString("F2"); // "F2" formats the time to two decimal places
    }
}

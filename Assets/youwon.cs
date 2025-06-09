using UnityEngine;
using UnityEngine.UI;

public class youwon : MonoBehaviour
{
    [SerializeField]
    private Text killCountText; // Reference to the Text component for displaying kill count
    [SerializeField]
    private Text timerText; // Reference to the Text component for displaying timer
    public GameObject[] stats;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("PlayerBody"))
        {
            // Check if the collider belongs to the player
            Health playerHealth = other.GetComponent<Health>();
            stats[0].SetActive(true);
            stats[1].SetActive(true);
            if (playerHealth != null)
            {
                // Update the kill count text
                if (killCountText != null)
                {
                    killCountText.text = "Kill Count: " + GameManager.Instance.killscount.ToString();
                }

                // Update the timer text
                if (timerText != null)
                {
                    timerText.text = "Timer: " + Mathf.Ceil(playerHealth.GetTimer()).ToString("F0");
                }
            }
        }
    }
}

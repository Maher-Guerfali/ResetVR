using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class LeaderboardManager : MonoBehaviour
{
    private int zombieKills;
    private int totalKills; // New variable to keep track of total kills

    public Text leaderboardText;
    public Text totalKillsText; // Text to display total kills on the leaderboard screen

    void Start()
    {
        // Load the total kills from PlayerPrefs on the leaderboard scene
        totalKills = PlayerPrefs.GetInt("TotalKills", 0);

        zombieKills = 0;
        UpdateLeaderboardText();
    }

    public void ZombieKilled()
    {
        zombieKills++;
        totalKills++; // Increment total kills as well
        UpdateLeaderboardText();
    }

    // Call this method to save the total kills to PlayerPrefs when switching scenes
    public void SaveTotalKills()
    {
        PlayerPrefs.SetInt("TotalKills", totalKills);
    }

    void UpdateLeaderboardText()
    {
        leaderboardText.text = "Player: " + zombieKills.ToString() + " kill";
    }

    // Call this method from the leaderboard screen to display the total kills
    public void DisplayTotalKills()
    {
        totalKillsText.text = "Total Kills: " + totalKills.ToString();
    }
}

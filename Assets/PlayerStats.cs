using UnityEngine;
using UnityEngine.UI;

public class PlayerStats : MonoBehaviour
{
    public int maxHealth = 100;
    public int initialMoney = 300;

    public int currentHealth;
    public int currentMoney;
    public Text healthText;
    public Text moneyText;

    private GameManager gameManager; // Reference to the GameManager script

    private void Start()
    {
        currentHealth = maxHealth;
        currentMoney = initialMoney;

        healthText = GameObject.Find("HealthText").GetComponent<Text>();
        moneyText = GameObject.Find("MoneyText").GetComponent<Text>();

        // Get the reference to the GameManager script
        gameManager = GameManager.Instance;

        UpdateHealthText();
        UpdateMoneyText();
    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;

        if (currentHealth <= 0)
        {
            Die();
        }

        UpdateHealthText();
    }

    public void Heal(int amount)
    {
        currentHealth = Mathf.Min(currentHealth + amount, maxHealth);
        UpdateHealthText();
    }

    public void AddMoney(int amount)
    {
        currentMoney += amount;
        UpdateMoneyText();
    }

    public void ReceiveEnemyDeathReward(int rewardAmount)
    {
        AddMoney(rewardAmount); // Add the reward amount to the player's money
    }

    private void UpdateHealthText()
    {
        healthText.text = "Health: " + currentHealth.ToString();
    }

    private void UpdateMoneyText()
    {
        moneyText.text = "Money: " + currentMoney.ToString();
    }

    private void Die()
    {
        // Handle player death here

        // Reset money to 0 when the player dies
        currentMoney = 0;
        UpdateMoneyText();
        Debug.Log("died");
    }
}

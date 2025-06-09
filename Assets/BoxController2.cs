using UnityEngine;

public class BoxController2 : MonoBehaviour
{
    public int price;
    public GameObject itemInsideBox;

    public bool isOpened = false;
    public GameObject player;

  

    public void OpenBox()
    {
        if (!isOpened)
        {
            // Get the PlayerStats component from the player GameObject
            PlayerStats playerStats = player.GetComponent<PlayerStats>();
            if (playerStats != null)
            {
                if (playerStats.currentMoney >= price)
                {
                    // Deduct the price from the player's money
                    playerStats.AddMoney(-price);
                    // Activate the item inside the box
                    itemInsideBox.SetActive(true);
                    // Mark the box as opened
                    isOpened = true;
                    // Destroy the box object
                    Destroy(gameObject);
                }
                else
                {
                    // Display a message to the player that they don't have enough money to open the box
                    Debug.Log("Not enough money to open the box!");
                }
            }
        }
    }
}

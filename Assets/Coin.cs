using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("PlayerBody"))
        {
            // Get the Health script from the player
            Health playerHealth = other.GetComponent<Health>();

            // Check if we successfully retrieved the Health script
            if (playerHealth != null)
            {
                // Add a coin to the player's coins count
                playerHealth.AddCoins(7);

                // Add health to the player
               // playerHealth.AddHealth(10); // Adjust the amount as needed

                // Destroy the coin GameObject
                Destroy(gameObject);
            }
        }
    }
}

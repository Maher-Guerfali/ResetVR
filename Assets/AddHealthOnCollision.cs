using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddHealthOnCollision : MonoBehaviour
{
    public float healthAmount = 20f; // Amount of health to add when the player collides with the potion
    public float regenDuration = 5f; // Duration over which health is regenerated
    private bool isBeingCollected = false; // Flag to track if the potion is currently being collected

    private void OnTriggerEnter(Collider other)
    {
        if (!isBeingCollected && other.CompareTag("PlayerBody"))
        {
            // Get the Health script from the player GameObject
            Health playerHealth = other.GetComponent<Health>();

            if (playerHealth != null)
            {
                // Start the health regeneration coroutine
                StartCoroutine(RegenerateHealth(playerHealth));

                // Set the flag to prevent multiple collections
                isBeingCollected = true;
            }
        }
    }

    private IEnumerator RegenerateHealth(Health playerHealth)
    {
        float elapsedTime = 0f;
        float regenerationRate = healthAmount / regenDuration;

        while (elapsedTime < regenDuration)
        {
            // Calculate the amount of health to add in this frame
            float healthToAdd = regenerationRate * Time.deltaTime;

            // Add health to the player
            playerHealth.AddHealth(healthToAdd);

            // Update elapsed time
            elapsedTime += Time.deltaTime;

            yield return null; // Wait for the next frame
        }

        // Ensure the player gets the full health amount
        playerHealth.AddHealth(healthAmount);

        // Destroy the potion GameObject after health is fully restored
        Destroy(gameObject);
    }
}

using UnityEngine;

public class PlayerHandController : MonoBehaviour
{
    public GameObject[] showcaseGuns; // An array of gun game objects to showcase above the cylinder
    public GameObject[] buyGunPrefabs; // An array of gun prefabs to be spawned when bought
    public Transform enemySpawnPoint; // The spawn point where the bought gun will be placed in front of the enemy
    public int[] weaponCosts; // An array of costs for each weapon

    private int currentGunIndex = 0; // Index of the currently displayed gun
    public GameObject playerHealth; // Reference to the player's health script
    private float coinsAvailable;

    private void Start()
    {
        coinsAvailable = playerHealth.GetComponent<Health>().coins;

        // Ensure the first gun is initially active in the showcase
        ShowGun(currentGunIndex);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Next"))
        {
            NextGun();
        }
         if (other.CompareTag("Buy"))
        {
            BuyCurrentGun();
        }
        
    }

    private void NextGun()
    {
        // Hide the current gun in the showcase
        HideGun(currentGunIndex);

        // Move to the next gun index
        currentGunIndex = (currentGunIndex + 1) % showcaseGuns.Length;

        // Show the new gun in the showcase
        ShowGun(currentGunIndex);
    }

    private void BuyCurrentGun()
    {
        int currentGunCost = weaponCosts[currentGunIndex];

        // Check if the player has enough coins to buy the gun and if coins are greater than zero
        if (coinsAvailable >= currentGunCost && coinsAvailable > 0)
        {
            // Deduct the gun's cost from the player's coins
            playerHealth.GetComponent<Health>().coins -= currentGunCost;
            coinsAvailable = playerHealth.GetComponent<Health>().coins;

            // Spawn the gun corresponding to the current index at the enemySpawnPoint position and rotation
            GameObject boughtGun = Instantiate(buyGunPrefabs[currentGunIndex], enemySpawnPoint.position, enemySpawnPoint.rotation);
            // Add any additional logic for the bought gun, e.g., handling ammunition or other effects
        }
        else
        {
            Debug.Log("Not enough coins to buy this weapon!");
        }
    }

    private void ShowGun(int index)
    {
        // Set the gun at the specified index to active (show it)
        showcaseGuns[index].SetActive(true);
    }

    private void HideGun(int index)
    {
        // Set all guns to inactive (hide them)
        foreach (GameObject gun in showcaseGuns)
        {
            gun.SetActive(false);
        }
    }
}

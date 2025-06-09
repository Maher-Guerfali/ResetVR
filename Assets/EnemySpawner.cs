using System.Collections;
using UnityEngine;
using UnityEngine.AI;

public class EnemySpawner : MonoBehaviour
{
    public GameObject enemyPrefab;
    public int numEnemiesPerWave = 5;
    public float delayBetweenEnemies = 3f;
    public float delayBetweenWaves = 3f;
    public Transform spawnPoint;
    public float spawnRadius = 35f;

    private int numEnemiesAlive = 0;
    private int maxHealth;
    private int currentHealth;
    private GameObject wall; // Reference to the wall GameObject

    public void Initialize(int spawnerMaxHealth)
    {
        maxHealth = spawnerMaxHealth;
        currentHealth = maxHealth;
    }

    public void SpawnEnemies()
    {
        StartCoroutine(SpawnEnemiesRoutine());
    }

    private IEnumerator SpawnEnemiesRoutine()
    {
        while (true)
        {
            for (int i = 0; i < numEnemiesPerWave; i++)
            {
                float randomX = Random.Range(transform.position.x - spawnRadius, transform.position.x + spawnRadius);
                float randomZ = Random.Range(transform.position.z - spawnRadius, transform.position.z + spawnRadius);

                Vector3 spawnPosition = new Vector3(randomX, 0, randomZ);
                GameObject enemy = Instantiate(enemyPrefab, spawnPosition, Quaternion.identity);

                numEnemiesAlive++;
                yield return new WaitForSeconds(delayBetweenEnemies);
            }

            yield return new WaitUntil(() => numEnemiesAlive == 0);

            yield return new WaitForSeconds(delayBetweenWaves);
        }
    }

    public void TakeDamage(int damageAmount)
    {
        currentHealth -= damageAmount;

        if (currentHealth <= 0)
        {
            GameManager.Instance.TakeDamage(maxHealth);
            // Call the OpenWall method in the GameManager when the spawner is destroyed
           
            Destroy(gameObject);
        }
    }

    public void EnemyDied()
    {
        numEnemiesAlive--;
    }

    // Method to set the wall corresponding to this spawner
    public void SetWall(GameObject wallObject)
    {
        wall = wallObject;
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }

    public List<GameObject> spawners;
    public int maxSpawnersHealth = 100;
    public GameObject[] walls; // Add the walls GameObjects here
    public Text killtext;
    public float spawnActivationDelay = 20.0f;
    public Vector3 playerspawn;
    private int currentSpawnersHealth;
    private int activeSpawnerIndex = 0; // Keep track of the active spawner index
    private bool isGameOver = false;
    public int killscount = 0;
    public GameObject xrPlayerPrefab1; // Assign the XR player prefab for scenario 1
    public GameObject xrPlayerPrefab2; // Assign the XR player prefab for scenario 2
    // New variables for enemy spawning
    public GameObject zombiePrefab;
    public GameObject zombiePrefab2; // Second enemy prefab
    public Transform[] spawnPoints;
    public float timeBetweenSpawns = 1f;
    public float timeBetweenWaves = 20f;
    public int minEnemiesPerWave = 20;
    public int maxEnemiesPerWave = 30;
    public AudioClip waveSound;
    public AudioClip waveend;
    public int waves;
    public Text wavenumbertext;
    private int waveNumber = 0; // Track the current wave number
    public AudioSource audioSource;
    private int enemiesRemaining; // Add this variable
    private bool useBothEnemyPrefabs = false; // Determine if both enemy prefabs should be used

    private void Awake()
    {
        Instance = this;
        int TouchFlag = PlayerPrefs.GetInt("TouchFlag", 2); // Default to scenario 1 if not set

        // Initialize the XR player prefab based on the scenario index
        GameObject xrPlayerPrefabToInstantiate = (TouchFlag == 1) ? xrPlayerPrefab1 : xrPlayerPrefab2;
        Instantiate(xrPlayerPrefabToInstantiate, playerspawn, Quaternion.identity);
    }

    private void Start()
    {
       
        // Initialize your game here
        killscount = 0;
        waveNumber = 0; // Track the current wave number
        //killtext.text = "kills: " + killscount.ToString();
        waves = 0;
        enemiesRemaining = 0;
        // Start spawning waves of enemies
      

    }

    public void startgame()
    {
        StartCoroutine(SpawnWaves());
    }
    public void nextwave()
    {
        killscount++; // Increment killscount
        OnEnemyDied();
        // Check if it's time to activate the next spawner based on killscount
        if (killscount == 7 || killscount == 16 || killscount == 29 || killscount == 45)
        {
            // StartCoroutine(ActivateSpawnerWithDelay());
        }

        // Update the kill count display
        killtext.text = "kills: " + killscount.ToString();
    }

    private IEnumerator ActivateSpawnerWithDelay()
    {
        yield return new WaitForSeconds(spawnActivationDelay);

        if (activeSpawnerIndex < spawners.Count)
        {
            spawners[activeSpawnerIndex].SetActive(true);
            activeSpawnerIndex++;
        }
    }

    public void TakeDamage(int damageAmount)
    {
        currentSpawnersHealth -= damageAmount;

        if (currentSpawnersHealth <= 0 && !isGameOver)
        {
            isGameOver = true;
            EndGame();
        }
    }

    private void EndGame()
    {
        // Game over logic (e.g., display game over screen, restart level, etc.)
        Debug.Log("Game Over");

        // Reload the current scene after a delay
        StartCoroutine(RestartScene());
    }

    private IEnumerator RestartScene()
    {
        yield return new WaitForSeconds(2f); // Wait for 2 seconds before restarting the scene

        // Reload the current scene
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

   

    public IEnumerator SpawnWaves()
    {
       
        if (waveNumber>0)
        {
            Debug.Log("start wave delay");
            yield return new WaitForSeconds(timeBetweenWaves);
            
        }
       
        waveNumber++;
        wavenumbertext.text = "wave: " + waveNumber;
        Debug.Log("Wave number: " + waveNumber);

                // Play wave sound (you'll need an AudioSource component)
                if (audioSource != null && waveSound != null)
                {
                    audioSource.PlayOneShot(waveSound);
                }

                int enemiesToSpawn;

                if (waveNumber <= 3)
                {
                    // First three waves, spawn both enemy prefabs
                    useBothEnemyPrefabs = true;
                    enemiesToSpawn = Random.Range(minEnemiesPerWave + waveNumber, maxEnemiesPerWave + waveNumber + 1);
                }
                else
                {
                    // Waves 4 and above, spawn only the second enemy prefab
                    useBothEnemyPrefabs = false;
                    enemiesToSpawn = Random.Range(minEnemiesPerWave + (waveNumber * 2), maxEnemiesPerWave + (waveNumber * 2) + 1);
                }

                enemiesRemaining = enemiesToSpawn;
                Debug.Log("Enemies remaining: " + enemiesRemaining);
        Debug.Log("start spawning = "+ enemiesToSpawn +" zombie ");

        for (int i = 0; i < enemiesToSpawn; i++)
                {
                    SpawnEnemy();
                    yield return new WaitForSeconds(timeBetweenSpawns);
                }
            

           
        
    }

    private void SpawnEnemy()
    {
        // Randomly select a spawn point
        int randomIndex = Random.Range(0, spawnPoints.Length);
        Transform spawnPoint = spawnPoints[randomIndex];

        // Instantiate an enemy (either the first or the second prefab based on useBothEnemyPrefabs)
        GameObject enemy = Instantiate(useBothEnemyPrefabs ? (Random.Range(0f, 1f) > 0.5f ? zombiePrefab : zombiePrefab2) : zombiePrefab2, spawnPoint.position, Quaternion.identity);

        // Attach a callback to the enemy's death event
        
    }

    // Callback when an enemy dies
    public void OnEnemyDied()
    {
        enemiesRemaining--;
        killscount++;
        Debug.Log("enemi remaingin= "+ enemiesRemaining);
        // Check if all enemies ar =e dead, and if so, start the wave delay again
        if (enemiesRemaining == 0)
        {
            audioSource.PlayOneShot(waveend);
            Debug.Log("wave ended");
            Debug.Log("wave ended = " + waveNumber);
            StartCoroutine(SpawnWaves());
        }
        else { return; }
    }
    // Method to open the wall when an enemy spawner is destroyed
    // Implement this based on your game's requirements
}

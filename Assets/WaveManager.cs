using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WaveManager : MonoBehaviour
{
    public Text waveText;

    // List of enemy spawners to be activated for each wave.
    public List<GameObject> enemySpawners;

    private static WaveManager _instance;

    public static WaveManager Instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = FindObjectOfType<WaveManager>();
                if (_instance == null)
                {
                    GameObject obj = new GameObject("WaveManager");
                    _instance = obj.AddComponent<WaveManager>();
                }
            }
            return _instance;
        }
    }

    private int currentWave = 0;
    private int[] waveEnemyCounts = { 7, 9, /* Add more wave counts here */ };

    private void Start()
    {
        ResetWave();
    }

    public void ResetWave()
    {
        currentWave = 0;
        UpdateWaveText();
        ActivateNextSpawner();
    }

    public void EnemyKilled()
    {
        if (currentWave < waveEnemyCounts.Length)
        {
            if (enemySpawners.Count > currentWave)
            {
             
                enemySpawners[currentWave].SetActive(false);
            }

            currentWave++;
            if (currentWave < waveEnemyCounts.Length)
            {
                ActivateNextSpawner();
            }
            else
            {
                // All waves are completed.
                Debug.Log("All waves completed.");
            }
        }
    }

    private void ActivateNextSpawner()
    {
        if (enemySpawners.Count > currentWave)
        {
            var spawner = enemySpawners[currentWave];
            spawner.gameObject.SetActive(true);
           
        }
    }

    private void UpdateWaveText()
    {
        if (waveText != null)
        {
            waveText.text = "Wave " + (currentWave + 1).ToString();
        }
    }
}

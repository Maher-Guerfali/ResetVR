using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PrefabSpawner : MonoBehaviour
{
    public GameObject prefab; // The prefab to spawn
    public float spawnInterval = 8f; // The time interval between spawns
    public Transform spawnPoint; // The point at which to spawn the prefab

    void Start()
    {
        StartCoroutine(SpawnPrefab());
    }

    IEnumerator SpawnPrefab()
    {
        while (true)
        {
            yield return new WaitForSeconds(spawnInterval); // Wait for the spawn interval

            Instantiate(prefab, spawnPoint.position, spawnPoint.rotation); // Spawn the prefab at the spawn point
        }
    }
}

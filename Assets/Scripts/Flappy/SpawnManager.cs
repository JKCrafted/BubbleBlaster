using System;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject pillarPrefab;

    public float spawnInterval = 8f;
    public float startXPosition = 15f;
    public float yPosition = 0f;
    public float zPosition = 0f;

    private float nextSpawnTime;

    private void Start()
    {
        // Instantiate(pillarPrefab, transform.position, Quaternion.identity);
         nextSpawnTime = Time.time + spawnInterval;
    }
    private void Update()
    {
        if (Time.time >= nextSpawnTime)
        {
            Instantiate(pillarPrefab, transform.position, Quaternion.identity);
            nextSpawnTime = Time.time + spawnInterval;
        }
    }

}
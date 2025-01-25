using System;
using UnityEngine;

namespace Flappy
{
    public class SpawnManager : MonoBehaviour
    {
        [SerializeField] private GameObject pillarPrefab;

        [SerializeField] public float spawnInterval = 4f;
        [SerializeField] private float startXPosition = 15f;
        [SerializeField] private float yPosition = 0f;
        [SerializeField] private float zPosition = 0f;


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
}
using System;
using UnityEngine;

namespace Flappy
{
    public class SpawnManager : MonoBehaviour
    {
        [SerializeField] private GameObject pillarPrefab;

        [SerializeField] public float spawnInterval = 4f;


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
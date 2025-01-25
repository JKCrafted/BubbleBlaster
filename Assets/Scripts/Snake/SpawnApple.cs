using UnityEngine;

namespace Snake
{
    public class SpawnApple : MonoBehaviour
    {
        [SerializeField] private GameObject apple;
        private Vector3 spawnPosition;
        private void Start()
        {
            SpawnAppleRun();
        }
        public void SpawnAppleRun()
        {
            spawnPosition = new Vector3(Random.Range(-11.5f, 11.5f), 1f, Random.Range(-5f, 5f));
            Instantiate(apple, spawnPosition, Quaternion.identity);
        }
    }
}
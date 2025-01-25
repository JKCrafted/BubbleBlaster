using UnityEngine;
using UnityEngine.Audio;

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
            spawnPosition = new Vector3(Random.Range(-10f, 10f), 1f, Random.Range(-5.5f, 5.5f));
            GameObject newApple = Instantiate(apple, spawnPosition, Quaternion.identity);
            newApple.GetComponent<AudioSource>().Play();
        }
    }
}
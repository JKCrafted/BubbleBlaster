using UnityEditor.ShaderGraph.Internal;
using UnityEngine;

namespace Asteriod
{
    public class BubbleMachine : MonoBehaviour
    {

        public GameObject Asteroid;
        public float radius;
        public float rotation;

        public int spawn_bubble_count;

        // Start is called once before the first execution of Update after the MonoBehaviour is created
        void Start()
        {
            spawnAsteroids();
        }

        public void spawnAsteroids()
        {
            for (int i = 0; i < spawn_bubble_count; i++)
            {
                Vector3 vector3_position = new Vector3(Random.Range(-radius, radius), Random.Range(-radius, radius), Random.Range(-radius, radius));
                Vector3 vector3_rotation = new Vector3(Random.Range(-rotation, rotation), Random.Range(-rotation, rotation), Random.Range(-rotation, rotation));

                GameObject bubble = Instantiate(Asteroid, vector3_position, Quaternion.Euler(vector3_rotation));
                bubble.name = "bubble_asteroid_" + i;
                bubble.transform.parent = transform;
            }
        }

        // Update is called once per frame
        void Update()
        {

        }
    }
}
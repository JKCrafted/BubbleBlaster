using JetBrains.Annotations;
using UnityEditor.ShaderGraph.Internal;
using UnityEngine;

public class BubbleMachine : MonoBehaviour
{

    public GameObject Asteroid;
    public float radius;
    public int spawn_bubble_count;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        for (int i = 0; i < spawn_bubble_count; i++)
        {
            Vector3 vector3 = new Vector3(Random.Range(-radius, radius), Random.Range(-radius, radius), Random.Range(-radius, radius));
            Instantiate(Asteroid, vector3, transform.rotation);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

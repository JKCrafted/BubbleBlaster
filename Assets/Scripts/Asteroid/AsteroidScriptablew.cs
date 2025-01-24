using UnityEngine;

public class AsteroidScriptablew : MonoBehaviour
{

    private Rigidbody rigidbody;
    public float asteroid_speed = 3f;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rigidbody = GetComponent<Rigidbody>();

        // When we spawn the object we want it to go in a random direction
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 current_pos = transform.position;

        if (current_pos.x < -75 || current_pos.x > 75 || current_pos.y < -75 || current_pos.y > 75)
        {
            // reverse direction of asteroid when it hits the edge of the map
            // how to change forward direction or do we just rotate object

        }

        current_pos += transform.forward * asteroid_speed * Time.deltaTime;

        transform.position = current_pos;
    }

    public void explodeAsteroidBubble()
    {
        // when this bubble is shot then it should explode!!!!
        // if not at lower limit of liquid then fully destroy
        // else spawn children objects and destroy.. do we spawn these in a seperate controller?
    }
}

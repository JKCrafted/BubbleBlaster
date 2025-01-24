using UnityEngine;

public class AsteroidScriptable : MonoBehaviour
{

    private Rigidbody rigidbody;
    public float asteroid_speed = 3f;
    public int children;
    public GameObject childBubbles;
    private AsteroidGameManager gameManager;
    public int points = 10;
    

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rigidbody = GetComponent<Rigidbody>();
        gameManager = GameObject.Find("AsteroidGameManager").GetComponent<AsteroidGameManager>();
        
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
        Debug.Log("BOOM!");

        // if we are size 1, then we dont spawn children
        if(transform.localScale.x == 1 ) { 
            Destroy(this.gameObject);
        }

        for (int i = 0; i < children; i++)
        {
            Vector3 child_pos = transform.position;
            child_pos.x += Random.Range(-1, 1);
            child_pos.y += Random.Range(-1, 1);

            GameObject child_bubble = Instantiate(this.gameObject, child_pos, transform.rotation);
            child_bubble.name = this.name + i;
            child_bubble.transform.parent = transform.parent;
            child_bubble.transform.localScale = new Vector3 (transform.localScale.x-1, transform.localScale.y-1, transform.localScale.z-1);
            child_bubble.gameObject.GetComponent<AsteroidScriptable>().asteroid_speed += 2f;

        }

        gameManager.updateScore(points);
        Destroy(this.gameObject);

    }

    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log(collision.gameObject.tag);
        if (collision.gameObject.tag == "Bullet")
        {
            explodeAsteroidBubble();
        }
    }
}

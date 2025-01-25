using UnityEngine;

namespace Asteriod
{
    public class AsteroidScriptable : MonoBehaviour
    {

        private new Rigidbody rigidbody;
        public float asteroid_speed = 3f;
        public int children;
        public GameObject childBubbles;
        private AsteroidGameManager gameManager;
        public int points = 10;
        public int rotation = 180;
        public float radius = 150;


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

            current_pos += transform.forward * asteroid_speed * Time.deltaTime;

            if (current_pos.x > radius)
            {
                current_pos.x = -radius;
            }
            else if (current_pos.x < -radius)
            {
                current_pos.x = radius;
            }

            if (current_pos.y > radius)
            {
                current_pos.y = -radius;
            }
            else if (current_pos.y < -radius)
            {
                current_pos.y = radius;
            }

            if (current_pos.z > radius)
            {
                current_pos.z = -radius;
            }
            else if (current_pos.z < -radius)
            {
                current_pos.z = radius;
            }

            transform.position = current_pos;
        }

        public void explodeAsteroidBubble()
        {
            // when this bubble is shot then it should explode!!!!
            // if not at lower limit of liquid then fully destroy
            // else spawn children objects and destroy.. do we spawn these in a seperate controller?

            // if we are size 1, then we dont spawn children
            if (transform.localScale.x == 1)
            {
                Destroy(this.gameObject);
            }

            for (int i = 0; i < children; i++)
            {
                Vector3 child_pos = transform.position;
                child_pos.x += Random.Range(-1, 1);
                child_pos.y += Random.Range(-1, 1);

                Vector3 vector3_rotation = new Vector3(Random.Range(-rotation, rotation), Random.Range(-rotation, rotation), Random.Range(-rotation, rotation));

                GameObject child_bubble = Instantiate(childBubbles, child_pos, Quaternion.Euler(vector3_rotation));
                child_bubble.name = this.name + i;
                child_bubble.transform.parent = transform.parent;
                child_bubble.transform.localScale = new Vector3(transform.localScale.x - 2, transform.localScale.y - 2, transform.localScale.z - 2);
                child_bubble.gameObject.GetComponent<AsteroidScriptable>().asteroid_speed += 2f;

                // add force in a random direction to child bubble
                child_bubble.GetComponent<Rigidbody>().AddForce(new Vector3(Random.Range(-1, 1), Random.Range(-1, 1), 0));

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

        private void OnCollisionExit(Collision collision)
        {

        }
    }
}
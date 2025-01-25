using UnityEngine;
using System.Collections;

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

        public Material[] material_mats;


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

            current_pos.x = WrapPosition(current_pos.x);
            current_pos.y = WrapPosition(current_pos.y);
            current_pos.z = WrapPosition(current_pos.z);

            transform.position = current_pos;

            CheckAndFlash(current_pos);
        }

        
        private float WrapPosition(float position)
        {
            if (position > radius)
            {
                return -radius;
            }
            else if (position < -radius)
            {
                return radius;
            }
            return position;
        }

        private void CheckAndFlash(Vector3 position)
        {
            if (Mathf.Abs(position.x) > radius * 0.9f || Mathf.Abs(position.y) > radius * 0.9f || Mathf.Abs(position.z) > radius * 0.9f)
            {
                StartCoroutine(Flash());
            }
        }

        private IEnumerator Flash()
        {
            MeshRenderer renderer = GetComponent<MeshRenderer>();
            Color originalColor = renderer.material.color;
            Color flashColor = Color.red;

            for (int i = 0; i < 5; i++)
            {
                renderer.material.color = flashColor;
                yield return new WaitForSeconds(0.1f);
                renderer.material.color = originalColor;
                yield return new WaitForSeconds(0.1f);
            }
        }
        public void explodeAsteroidBubble()
        {
            // when this bubble is shot then it should explode!!!!
            // if not at lower limit of liquid then fully destroy
            // else spawn children objects and destroy.. do we spawn these in a seperate controller?

            // Player gets points for each bubble destroyed
            if (gameManager != null) {
                gameManager.updateScore(points);
            } else {
                gameManager = GameObject.Find("AsteroidGameManager").GetComponent<AsteroidGameManager>();
                gameManager.updateScore(points);
            }
 
            if(children > 1) {
                for (int i = 0; i < children; i++)
                {
                    Vector3 child_pos = transform.position + new Vector3(Random.Range(-1, 1), Random.Range(-1, 1), 0);
                    Vector3 vector3_rotation = new Vector3(Random.Range(-rotation, rotation), Random.Range(-rotation, rotation), Random.Range(-rotation, rotation));

                    GameObject child_bubble = Instantiate(childBubbles, child_pos, Quaternion.Euler(vector3_rotation));
                    child_bubble.name = this.name + i;
                    child_bubble.transform.parent = transform.parent;
                    child_bubble.transform.localScale = transform.localScale - new Vector3(2, 2, 2);

                    AsteroidScriptable child_script = child_bubble.GetComponent<AsteroidScriptable>();
                    child_script.asteroid_speed += 2f; // Increase speed as it gets smaller
                    child_script.children = children - 1; // reduce the number of children compared to the parent.

                    Rigidbody child_rigidbody = child_bubble.GetComponent<Rigidbody>();
                    child_rigidbody.AddForce(new Vector3(Random.Range(-1, 1), Random.Range(-1, 1), 0) * 100);

                    MeshRenderer child_renderer = child_bubble.GetComponent<MeshRenderer>();
                    child_renderer.material = material_mats[0];
                }
            }
    
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
}
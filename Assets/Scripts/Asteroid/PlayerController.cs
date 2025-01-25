using System;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

namespace Asteriod
{
    public class PlayerController : MonoBehaviour
    {
        private new Rigidbody rigidbody;
        private AsteroidGameManager gameManager;

        public int shields;
        public float speed = 15f;
        public float pitch_speed = 100f;
        public float yaw_speed = 100f;
        public float radius = 150;

        public GameObject bullet;

        Vector3 velocity;

        void Start()
        {
            rigidbody = GetComponent<Rigidbody>();
            gameManager = GameObject.Find("AsteroidGameManager").GetComponent<AsteroidGameManager>();
        }

        void Update()
        {
            playerMovement();

            if (Input.GetKeyDown(KeyCode.Space))
            {
                GameObject gun = GameObject.FindWithTag("Gun");
                Instantiate(bullet, gun.transform.position, gun.transform.rotation);
            }
        }

        private void OnCollisionEnter(Collision collision)
        {
            if (collision.gameObject.tag == "Asteroid")
            {
                gameManager.takeDamage(1);
            }
        }

        public void playerMovement()
        {
            float hor_input = Input.GetAxis("Horizontal");
            float ver_input = Input.GetAxis("Vertical");

            Vector3 current_pos = transform.position;

            current_pos += transform.forward * speed * Time.deltaTime;
            current_pos += (transform.right * hor_input) * speed * Time.deltaTime;
            current_pos += (transform.up * ver_input) * speed * Time.deltaTime;

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

            float pitchDelta = ver_input * pitch_speed * Time.deltaTime;
            float yawDelta = hor_input * yaw_speed * Time.deltaTime;

            transform.rotation *= Quaternion.Euler(pitchDelta, yawDelta, 0);


        }
    }

}
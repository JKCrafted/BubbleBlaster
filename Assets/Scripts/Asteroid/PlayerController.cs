using System;
using UnityEngine;
using System.Collections;

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
        public GameObject instructions;

        private bool showing_instructions;
        public AudioSource audio_source;
        public AudioClip[] shooting_sounds;
        public AudioClip explode_sound;

        Vector3 velocity;

        void Start()
        {
            rigidbody = GetComponent<Rigidbody>();
            gameManager = GameObject.Find("AsteroidGameManager").GetComponent<AsteroidGameManager>();
            showing_instructions = true;
        }

        void Update()
        {   

            if (showing_instructions)
            {
                if (Input.GetKeyDown(KeyCode.Space))
                {
                    showing_instructions = false;
                    instructions.SetActive(false);
                    gameManager.restartGame();
                }
                return;
            }
            
            playerMovement();

            if (Input.GetKeyDown(KeyCode.Space))
            {
                audio_source.PlayOneShot(shooting_sounds[UnityEngine.Random.Range(0, shooting_sounds.Length)]);
                GameObject gun = GameObject.FindWithTag("Gun");
                Instantiate(bullet, gun.transform.position, gun.transform.rotation);

            }
        }

        public IEnumerator Shake(float duration, float magnitude)
        {
            Vector3 startPosition = transform.position;
            float elapsed = 0f;
    
            while (elapsed < duration)
            {
                float shakeX = UnityEngine.Random.Range(-1f, 1f) * magnitude;
                float shakeY = UnityEngine.Random.Range(-1f, 1f) * magnitude;
    
                transform.position = Vector3.Slerp(new Vector3(startPosition.x, startPosition.y, startPosition.z),
                    new Vector3(startPosition.x + shakeX, startPosition.y + shakeY, startPosition.z), 0.2f);
                elapsed += Time.deltaTime;
    
                yield return null;
            }
    
            transform.position = startPosition;
        }

        private void OnCollisionEnter(Collision collision)
        {
            if (collision.gameObject.tag == "Asteroid")
            {
                gameManager.takeDamage(1);
                StartCoroutine(Shake(3, 0.2f));
            }
            if(collision.gameObject.tag == "EnemyShip")
            {
                gameManager.takeDamage(1);
                StartCoroutine(Shake(3, 0.2f));
            }
            if(collision.gameObject.tag == "EnemyShipBullet")
            {
                gameManager.takeDamage(1);
                StartCoroutine(Shake(3, 0.2f));
            }
            audio_source.PlayOneShot(explode_sound);
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
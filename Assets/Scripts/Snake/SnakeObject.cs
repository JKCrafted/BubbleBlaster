using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

namespace Snake
{
    public class SnakeObject : MonoBehaviour
    {
        private TextMeshProUGUI scoreText;
        private int score = 0;
        private GameManager gameManager;
        public GameObject snakeEnd;
        private Rigidbody rb;
        private SpawnApple spawnApple;
        bool running = true;
        [SerializeField] private float speed = 100f;
        private int wallHits = 0;
        // Start is called once before the first execution of Update after the MonoBehaviour is created
        void Start()
        {
            gameManager = FindObjectOfType<GameManager>();
            spawnApple = FindObjectOfType<SpawnApple>();
            rb = GetComponent<Rigidbody>();
            scoreText = FindObjectOfType<TextMeshProUGUI>();
            scoreText.text = "Score: " + score.ToString();
        }

        // Update is called once per frame
        void Update()
        {
            //Debug.Log("Old");
            //Debug.Log(rb.linearVelocity);
            transform.rotation = Quaternion.identity;

            if (running)
            {
                if (rb.linearVelocity.x > 5)
                {
                    Vector3 newVelocity = rb.linearVelocity;
                    newVelocity.x = 5;
                    rb.linearVelocity = newVelocity;
                }
                if (rb.linearVelocity.y > 5)
                {
                    Vector3 newVelocity = rb.linearVelocity;
                    newVelocity.y = 5;
                    rb.linearVelocity = newVelocity;
                }
                if (rb.linearVelocity.z > 5)
                {
                    Vector3 newVelocity = rb.linearVelocity;
                    newVelocity.z = 5;
                    rb.linearVelocity = newVelocity;
                }
                //Debug.Log("New");
                //Debug.Log(rb.linearVelocity);
                if (Input.GetKeyDown(KeyCode.W))
                {
                    rb.AddForce(Vector3.forward * speed);
                }
                if (Input.GetKeyDown(KeyCode.S))
                {
                    rb.AddForce(Vector3.back * speed);
                }
                if (Input.GetKeyDown(KeyCode.A))
                {
                    rb.AddForce(Vector3.left * speed);
                }
                if (Input.GetKeyDown(KeyCode.D))
                {
                    rb.AddForce(Vector3.right * speed);
                }
                if (rb.linearVelocity.x < 1 && !(rb.linearVelocity.x < 0) || rb.linearVelocity.x > -1 && !(rb.linearVelocity.x > 0))
                {
                    Vector3 newVelocity = rb.linearVelocity;
                    newVelocity.x = 0;
                    rb.linearVelocity = newVelocity;
                }
                if (rb.linearVelocity.y < 1 && !(rb.linearVelocity.y < 0) || rb.linearVelocity.y > -1 && !(rb.linearVelocity.y > 0))
                {
                    Vector3 newVelocity = rb.linearVelocity;
                    newVelocity.y = 0;
                    rb.linearVelocity = newVelocity;
                }
                if (rb.linearVelocity.z < 1 && !(rb.linearVelocity.z < 0) || rb.linearVelocity.z > -1 && !(rb.linearVelocity.z > 0))
                {
                    Vector3 newVelocity = rb.linearVelocity;
                    newVelocity.z = 0;
                    rb.linearVelocity = newVelocity;
                }
            }

        }

        private void OnCollisionEnter(Collision collision)
        {
            if (running)
            {

                if (collision.gameObject.name.Contains("Apple"))
                {
                    GrowSnake(collision.gameObject);
                }
                else if (collision.gameObject.name.Contains("Wall") || (collision.gameObject.name.Contains("Snake") && collision.gameObject != gameManager.snake[1]))
                {
                    GameEnd();
                }
            }
        }

        private void GrowSnake(GameObject consumed)
        {
            rb.linearVelocity = Vector3.zero;
            score++;
            scoreText.text = "Score: " + score.ToString();
            Destroy(consumed);
            Vector3 spawnPos = gameManager.snake[gameManager.snake.Count - 1].transform.position;
            spawnPos.y += 1;
            GameObject newSnakeEnd = Instantiate(snakeEnd, spawnPos, Quaternion.identity);
            gameManager.snake.Add(newSnakeEnd);
            spawnApple.SpawnAppleRun();
        }
        private void GameEnd()
        {
            StartCoroutine(TakeHit());
            if (wallHits > 8)
            {
                running = false;
                for (int i = 1; i < gameManager.snake.Count; i++)
                {
                    Destroy(gameManager.snake[i].GetComponent<SnakeEnd>());
                }

                for (int i = 0; i < gameManager.snake.Count; i++)
                {
                    StartCoroutine(DestroySnake((gameManager.snake.Count - 1 - i), gameManager.snake[i]));
                    //            Destroy(gameManager.snake[i].GetComponent<SnakeEnd>());
                }
            }
            else
            {
                wallHits += 1;
            }



        }

        private IEnumerator TakeHit()
        {
            for (int i = 0;i < gameManager.snake.Count;i++)
            {
                if (i == 0)
                {
                    gameManager.snake[i].GetComponent<MeshRenderer>().material = gameManager.snakeMaterials[2];
                }
                else
                {
                    gameManager.snake[i].GetComponent<MeshRenderer>().material = gameManager.snakeMaterials[3];
                }
            }
            yield return new WaitForSeconds(3.5f*Time.deltaTime);
            for (int i = 0; i < gameManager.snake.Count; i++)
            {
                if (i == 0)
                {
                    gameManager.snake[i].GetComponent<MeshRenderer>().material = gameManager.snakeMaterials[0];
                }
                else
                {
                    gameManager.snake[i].GetComponent<MeshRenderer>().material = gameManager.snakeMaterials[1];
                }
            }
        }

        private IEnumerator DestroySnake(int time, GameObject item)
        {
            gameManager.runEnd = true;
            gameManager.score = score;
            yield return new WaitForSeconds(0.5f * time);
            gameManager.snake.Remove(item);
            Destroy(item);
        }
    }
}
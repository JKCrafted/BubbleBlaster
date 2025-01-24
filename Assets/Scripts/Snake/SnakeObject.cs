using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class SnakeObject : MonoBehaviour
{
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
    }

    // Update is called once per frame
    void Update()
    {
        if (running)
        {
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
        Destroy(consumed);
        Vector3 spawnPos = gameManager.snake[gameManager.snake.Count-1].transform.position;
        spawnPos.y += 1;
        GameObject newSnakeEnd = Instantiate(snakeEnd, spawnPos, Quaternion.identity);
        gameManager.snake.Add(newSnakeEnd);
        spawnApple.SpawnAppleRun();
    }
    private void GameEnd()
    {
        if (wallHits > 20)
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
    private IEnumerator DestroySnake(int time, GameObject item)
    {
        yield return new WaitForSeconds(2f*time);
        Destroy(item);
    }
}

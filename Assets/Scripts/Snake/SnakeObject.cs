using UnityEngine;

public class SnakeObject : MonoBehaviour
{
    private GameManager gameManager;
    public GameObject snakeEnd;
    private Rigidbody rb;
    private SpawnApple spawnApple;
    [SerializeField] private float speed = 100f;
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

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.name.Contains("Apple"))
        {
            GrowSnake(collision.gameObject);
        }
        else if (collision.gameObject.name.Contains("Wall") || collision.gameObject.name.Contains("Snake"))
        {
            GameEnd();
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

    }
}

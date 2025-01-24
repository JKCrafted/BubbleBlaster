using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnakeEnd : MonoBehaviour
{
    private GameObject snakeHead;
    private GameManager gameManager;
    private int index;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        gameManager = FindObjectOfType<GameManager>();
        index = gameManager.snake.Count - 1;
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 moveTo = gameManager.snake[index - 1].transform.position;
        StartCoroutine(MovePos(moveTo));
        //transform.position = Vector3.MoveTowards(transform.position, moveTo, 5f);
    }

    IEnumerator MovePos (Vector3 moveTo)
    {
        yield return new WaitForSeconds(0.2f*Time.deltaTime);
        transform.position = Vector3.MoveTowards(transform.position, moveTo, 5f);
    }
}

using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

namespace Snake
{
    public class SnakeEnd : MonoBehaviour
    {
        private GameObject snakeHead;
        private GameManager gameManager;
        private int index;
        //Vector3 moveTo;
        // Start is called once before the first execution of Update after the MonoBehaviour is created
        void Start()
        {
            gameManager = FindFirstObjectByType<GameManager>();
            index = gameManager.snake.Count - 1;
            //float timer = 0;

        }

        // Update is called once per frame
        void FixedUpdate()
        {

            //if (timer == 0)
            //{
            //    moveTo = gameManager.snake[index - 1].transform.position;
            //
            //}
            //timer += Time.fixedDeltaTime;
            //if (timer >= 2.0f)
            //{
            //   //Vector3 moveTo = gameManager.snake[index - 1].transform.position;
            //   transform.position = Vector3.MoveTowards(transform.position, moveTo, 5f);
            //   //            break;
            //    timer = 0;
            //}



            //transform.position = Vector3.MoveTowards(transform.position, moveTo, 5f);
            Vector3 moveTo = gameManager.snake[index - 1].transform.position;
            StartCoroutine(MovePos(moveTo));
        }





        IEnumerator MovePos(Vector3 moveTo)
        {
            yield return new WaitForSeconds(18f * Time.fixedDeltaTime);
            transform.position = Vector3.MoveTowards(transform.position, moveTo, 5f);
        }
    }
}
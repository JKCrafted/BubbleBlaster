using NUnit.Framework;
using System.Collections.Generic;
using UnityEngine;

namespace Snake
{
    public class GameManager : MonoBehaviour
    {
        public List<GameObject> snake = new List<GameObject>();
        // Start is called once before the first execution of Update after the MonoBehaviour is created
        void Start()
        {
            snake.Add(FindObjectOfType<SnakeObject>().gameObject);
        }

        // Update is called once per frame
        void Update()
        {
        
        }
    }
}


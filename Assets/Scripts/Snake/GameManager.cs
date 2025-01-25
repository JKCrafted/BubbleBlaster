using NUnit.Framework;
using System.Collections.Generic;
using UnityEngine;
using BubbleWubble;

namespace Snake
{
    public class GameManager : MonoBehaviour
    {
        public List<GameObject> snake = new List<GameObject>();
        public bool runEnd = false;
        public int score;
        private EndState endState;
        public int passingScore;
        public List<Material> snakeMaterials = new List<Material>();
        // Start is called once before the first execution of Update after the MonoBehaviour is created
        void Start()
        {
            snake.Add(FindFirstObjectByType<SnakeObject>().gameObject);
            endState = FindFirstObjectByType<EndState>();
            runEnd = false;
        }

        // Update is called once per frame
        void Update()
        {
            if (runEnd && snake.Count == 0)
            {
                if (score >= passingScore)
                {
                    endState.winThreshold = true;
                }
                endState.GameEnd();
            }
        }

    }
}


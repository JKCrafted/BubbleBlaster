using NUnit.Framework;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace BubbleWubble
{
    public class EndState : MonoBehaviour
    {
        private TextMeshProUGUI ending;
        public TextMeshProUGUI score;
        private TextMeshProUGUI replay;
        private TextMeshProUGUI timer;
        public bool timerEnabled = false;
        public int timerLength = 0;
        public int timerLeft;
        public bool winThreshold = false;
        public GameObject fade;
        public Color color = Color.white;
        public float firstDelay = 5f;
        public float secondDelay = 2f;
        private bool timerRunning = false;

        public bool isEnding = false;

        // Start is called once before the first execution of Update after the MonoBehaviour is created
        void Start()
        {

            //Debug.Log("Running");
            for (int i = 0; i < transform.childCount; i++)
            {
                //Debug.Log(i);
                GameObject item = transform.GetChild(i).gameObject;
                if (item.tag.Contains("EndingScore"))
                {
                    score = item.GetComponent<TextMeshProUGUI>();
                }
                else if (transform.GetChild(i).gameObject.tag.Contains("EndingEnding"))
                {
                    ending = item.GetComponent<TextMeshProUGUI>();
                }
                else if (transform.GetChild(i).gameObject.tag.Contains("EndingReplay"))
                {
                    replay = item.GetComponent<TextMeshProUGUI>();
                }
                else if (transform.GetChild(i).gameObject.tag.Contains("EndingTimer"))
                {
                    timer = item.GetComponent<TextMeshProUGUI>();
                }
            }



            //score = GameObject.FindWithTag("EndingScore").GetComponent<TextMeshProUGUI>();
           // ending = GameObject.FindWithTag("EndingEnding").GetComponent<TextMeshProUGUI>();
            //replay = GameObject.FindWithTag("EndingReplay").GetComponent<TextMeshProUGUI>();

        }

        void Update() 
        {
            if (timerEnabled = true && !timerRunning) 
            {
                timer.gameObject.SetActive(true);
                timerEnabled = false;
                timerLeft = timerLength;
                StartCoroutine(RunTimer());
            }
        }


        public IEnumerator RunTimer()
        {
            timerRunning = true;
            if (timerLeft > 0)
            {
                timer.text = "Time Remaining: " + timerLeft.ToString() +"s";
                yield return new WaitForSeconds(1f);
                timerLeft-=1;
                StartCoroutine(RunTimer());
            }
            else
            {
                GameEnd();
            }
        }



        public void GameEnd()
        {
            //Debug.Log("Game Over1!");

            if (isEnding == false)
            {
                StartCoroutine(GameEndCoroutine());
            }
        }

        public void ReplayYes()
        {
            Cursor.lockState = false ? CursorLockMode.Confined : CursorLockMode.Locked;

            Cursor.visible = false;
            StartCoroutine(LoadingScene(SceneManager.GetActiveScene().name, color, 1.5f));
        }
        public void ReplayNo()
        {
            Cursor.lockState = false ? CursorLockMode.Confined : CursorLockMode.Locked;

            Cursor.visible = false;
            StartCoroutine(LoadingScene("scene_hub", Color.white, 1.5f));
        }

        IEnumerator LoadingScene(string input, Color colour, float speed)
        {
            GameObject newFade = Instantiate(fade);
            newFade.transform.SetParent(transform);
            FadeEffect fadeEffect = newFade.GetComponent<FadeEffect>();
            fadeEffect.gameObject.transform.GetChild(0).GetComponent<Image>().color = colour;   
            fadeEffect.fadingSpeed = speed;
            yield return new WaitForSeconds(speed+0.1f);
            if (input == "scene_hub")
            {
                //Debug.Log("You won? " + winThreshold.ToString());
                if (SceneManager.GetActiveScene().name.Contains("Snake")) { BubbleGame.Instance.ReturnToHub(BubbleGame.MinigameType.Snake, winThreshold); }
                else if (SceneManager.GetActiveScene().name.Contains("Asteroid")) { BubbleGame.Instance.ReturnToHub(BubbleGame.MinigameType.Asteroids, winThreshold); }
                else if (SceneManager.GetActiveScene().name.Contains("Flappy")) { BubbleGame.Instance.ReturnToHub(BubbleGame.MinigameType.Flappy, winThreshold); }
            }
            else
            {
                SceneManager.LoadScene(input);
            }
            
        }

        // Update is called once per frame
        IEnumerator GameEndCoroutine()
        {
            isEnding = true;
            //Debug.Log("Entered coroutine");

            if (winThreshold)
            {
                ending.text = "You earned a key!";
            }
            else
            {
                ending.text = "";
            }

            ending.gameObject.SetActive(true);

            yield return new WaitForSeconds(firstDelay);

            //Debug.Log("Past the point");
            
            score.gameObject.SetActive(false);
            ending.gameObject.SetActive(false);

            yield return new WaitForSeconds(secondDelay);
            Cursor.lockState = true ? CursorLockMode.Confined : CursorLockMode.Locked;

            Cursor.visible = true;
            replay.gameObject.SetActive(true);

        }
    }
}
using NUnit.Framework;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace BubbleWubble
{
    public class EndState : MonoBehaviour
    {
        private TextMeshProUGUI ending;
        private TextMeshProUGUI score;
        private TextMeshProUGUI replay;
        public bool winThreshold = false;
        // Start is called once before the first execution of Update after the MonoBehaviour is created
        void Start()
        {

            Debug.Log("Running");
            for (int i = 0; i < transform.childCount; i++)
            {
                Debug.Log(i);
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
            }



            //score = GameObject.FindWithTag("EndingScore").GetComponent<TextMeshProUGUI>();
           // ending = GameObject.FindWithTag("EndingEnding").GetComponent<TextMeshProUGUI>();
            //replay = GameObject.FindWithTag("EndingReplay").GetComponent<TextMeshProUGUI>();

        }

        public void GameEnd()
        {

            StartCoroutine(GameEndCoroutine());
        }

        public void ReplayYes()
        {
            Cursor.lockState = false ? CursorLockMode.Confined : CursorLockMode.Locked;

            Cursor.visible = false;
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
        public void ReplayNo()
        {
            Cursor.lockState = false ? CursorLockMode.Confined : CursorLockMode.Locked;

            Cursor.visible = false;
            SceneManager.LoadScene("scene_hub");
        }


        // Update is called once per frame
        IEnumerator GameEndCoroutine()
        {
            if (winThreshold)
            {
                ending.text = "You earned a key!";
            }
            else
            {
                ending.text = "";
            }
            ending.gameObject.SetActive(true);
            yield return new WaitForSeconds(5f);
            score.gameObject.SetActive(false);
            ending.gameObject.SetActive(false);

            yield return new WaitForSeconds(2f);
            Cursor.lockState = true ? CursorLockMode.Confined : CursorLockMode.Locked;

            Cursor.visible = true;
            replay.gameObject.SetActive(true);

        }
    }
}
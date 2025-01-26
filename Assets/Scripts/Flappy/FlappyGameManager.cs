using BubbleWubble;
using TMPro;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

public class FlappyGameManager : MonoBehaviour
{
    [SerializeField] private int playerScore;
    [SerializeField] private GameObject scoreUI;
    public float pillarSpeed = 1f;
    private EndState endState;
    public int passingScore = 50;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        endState = FindFirstObjectByType<EndState>();
        scoreUI = FindObjectOfType<EndState>().score.gameObject;
        UpdateScore(0);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void UpdateScore(int score)
    {
        playerScore += score;
        // update ui textmesh pro

        scoreUI.GetComponent<TextMeshProUGUI>().text = "Score: " + playerScore;
    }

    public void GameOver()
    {

        if (playerScore >= passingScore)
        {
            Debug.Log("You Win!");
            endState.winThreshold = true;
        }
        Debug.Log("Game Over!");
        endState.GameEnd();
    }

}

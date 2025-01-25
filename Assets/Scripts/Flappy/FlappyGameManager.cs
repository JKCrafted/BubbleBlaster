using BubbleWubble;
using UnityEngine;

public class FlappyGameManager : MonoBehaviour
{
    [SerializeField] private int playerScore;
    [SerializeField] private GameObject scoreUI;
    public float pillarSpeed = 1f;
    private EndState endState;
    public int passingScore;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        endState = FindFirstObjectByType<EndState>();
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

        scoreUI.GetComponent<TMPro.TextMeshProUGUI>().text = "Score: " + playerScore;
    }

    public void GameOver()
    {
        Debug.Log("Game Over!");
        Time.timeScale = 0;
        if (playerScore >= passingScore)
        {
            endState.winThreshold = true;
        }
        endState.GameEnd();
    }

}

using UnityEngine;

public class FlappyGameManager : MonoBehaviour
{
    [SerializeField] private int playerScore;
    [SerializeField] private GameObject scoreUI;
    public float pillarSpeed = 1f;

    [SerializeField] private int targetScore = 10;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        UpdateScore(0);
    }

    // Update is called once per frame
    void Update()
    {
        CheckTargetScore();
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
    }

    public void CheckTargetScore()
    {
        if (playerScore >= targetScore)
        {
            GameWon();
        }
    }

}

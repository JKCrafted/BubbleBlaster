using UnityEngine;

public class AsteroidGameManager : MonoBehaviour
{
    public int player_score;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void updateScore(int score)
    {
        player_score += score;
    }
}

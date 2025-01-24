using UnityEngine;

public class AsteroidGameManager : MonoBehaviour
{
    public int player_score;
    public GameObject score_ui;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        updateScore(0); 
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void updateScore(int score)
    {
        player_score += score;
        // update ui textmesh pro

        score_ui.GetComponent<TMPro.TextMeshProUGUI>().text = "Score: " + player_score;
    }
}

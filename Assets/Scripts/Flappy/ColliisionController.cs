using UnityEngine;

public class ColliisionController : MonoBehaviour
{

    private FlappyGameManager gameManager;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        gameManager = GameObject.Find("FlappyGameManager").GetComponent<FlappyGameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        // Debug.Log("Collided with pillar!");
        gameManager.GameOver();
    }

}

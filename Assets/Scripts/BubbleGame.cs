using UnityEngine;
using UnityEngine.SceneManagement;

public class BubbleGame : MonoBehaviour
{
    public static BubbleGame Instance;



    private void Awake()
    {
        Instance = this;
        DontDestroyOnLoad(gameObject);
    }


    public void ReturnToHub(bool success = false)
    {
        SceneManager.LoadScene(0);
    }
}

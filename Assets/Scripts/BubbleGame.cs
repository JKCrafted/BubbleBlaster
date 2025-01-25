using UnityEngine;
using UnityEngine.SceneManagement;

public class BubbleGame : MonoBehaviour
{
    public static BubbleGame Instance;

    [SerializeField]
    private CutsceneSystem cutsceneSystem;


    private void Awake()
    {
        Instance = this;
        DontDestroyOnLoad(gameObject);
    }


    public void ReturnToHub(bool success = false)
    {
        SceneManager.LoadScene(0);


    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.C))
        {
            cutsceneSystem.PlayCutscene("cs_test");
        }
    }
}

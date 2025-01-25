using UnityEngine;
using UnityEngine.SceneManagement;

public class HubPortal : MonoBehaviour
{
    [SerializeField]
    private int sceneToLoad;


    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag.Equals("Player"))
        {
            if (BubbleWubble.BubbleGame.Instance != null)
            {
                BubbleWubble.BubbleGame.Instance.SwitchScene(sceneToLoad);
            }
        }
    }
}

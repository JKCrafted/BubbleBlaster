using UnityEngine;

public class CutsceneSystem : MonoBehaviour
{
    [SerializeField]
    private Animator cutsceneAnimator;

    [SerializeField]
    private GameObject playerObject;

    bool cutscenePlaying = false;

    public void PlayCutscene(string cutsceneID)
    {
        if (!cutscenePlaying)
        {
            playerObject.gameObject.SetActive(false);

            cutsceneAnimator.Play(cutsceneID);

            cutscenePlaying = true;
        }
    }

    public void RestorePlayerCam()
    {
        cutscenePlaying = false;
        playerObject.gameObject.SetActive(true);
    }
}

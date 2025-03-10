using BubbleWubble;
using UnityEngine;

public class PortalManager : MonoBehaviour
{
    [SerializeField]
    private AYellowpaper.SerializedCollections.SerializedDictionary<BubbleGame.MinigameType, GameObject> minigamePortals;

    [SerializeField]
    private CutsceneSystem cutsceneSystem;

    /// <summary>
    /// Unity Start()
    /// Check what games have been beat and close those portals.
    /// </summary>
    void Start()
    {
        var attemptedMinigames = BubbleGame.Instance.GetAttemptedMinigames();

        if (BubbleGame.Instance.gameComplete)
        {
            cutsceneSystem.PlayEndingCutscene();
        }

        foreach (var minigame in attemptedMinigames)
        {
            if (minigame.Value == true)
            {
                if (minigamePortals.ContainsKey(minigame.Key))
                {
                    minigamePortals[minigame.Key].gameObject.SetActive(false);

                    if (!BubbleGame.Instance.gameComplete)
                    {
                        cutsceneSystem.PlayMinigameFinishedCutscene(minigame.Key);
                    }
                }
            }
        }
    }
}

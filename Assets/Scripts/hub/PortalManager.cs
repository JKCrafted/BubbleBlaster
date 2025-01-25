using BubbleWubble;
using UnityEngine;

public class PortalManager : MonoBehaviour
{
    [SerializeField]
    AYellowpaper.SerializedCollections.SerializedDictionary<BubbleGame.MinigameType, GameObject> minigamePortals;

    /// <summary>
    /// Unity Start()
    /// Check what games have been beat and close those portals.
    /// </summary>
    void Start()
    {
        var attemptedMinigames = BubbleGame.Instance.GetAttemptedMinigames();

        foreach (var minigame in attemptedMinigames)
        {
            if (minigame.Value == true)
            {
                if (minigamePortals.ContainsKey(minigame.Key))
                {
                    minigamePortals[minigame.Key].gameObject.SetActive(false);
                }
            }
        }
    }
}

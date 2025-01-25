namespace BubbleWubble
{
    using UnityEngine;

    /// <summary>
    /// The portal into the minigames from the HUB.
    /// </summary>
    public class HubPortal : MonoBehaviour
    {
        [SerializeField]
        [Tooltip("Scene ID from build hierarchy")]
        private int sceneToLoad;

        /// <summary>
        /// When the player collides with us, switch the scene!
        /// </summary>
        /// <param name="other">Who collided with us?</param>
        private void OnTriggerEnter(Collider other)
        {
            if (other.gameObject.tag.Equals("Player"))
            {
                if (BubbleGame.Instance != null)
                {
                    BubbleGame.Instance.SwitchScene(sceneToLoad);
                }
            }
        }
    }
}



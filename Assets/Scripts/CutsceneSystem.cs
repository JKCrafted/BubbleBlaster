namespace BubbleWubble
{
    using UnityEngine;
    
    /// <summary>
    /// The system wot plays our cutscenes in the game.
    /// </summary>
    public class CutsceneSystem : MonoBehaviour
    {
        [SerializeField]
        [Tooltip("Animator that controls the cutscenes.")]
        private Animator cutsceneAnimator;

        [SerializeField]
        [Tooltip("A ref to the hub player object.")]
        private GameObject playerObject;

        /// <summary>
        /// Is a cutscene playing right now?
        /// </summary>
        bool cutscenePlaying = false;

        /// <summary>
        /// Play a cutscene, cut out gameplay.
        /// </summary>
        /// <param name="cutsceneID">String anim ID</param>
        public void PlayCutscene(string cutsceneID)
        {
            if (!cutscenePlaying)
            {
                playerObject.gameObject.SetActive(false);

                cutsceneAnimator.Play(cutsceneID);

                cutscenePlaying = true;
            }
        }

        /// <summary>
        /// Give the player their camera back.
        /// </summary>
        public void RestorePlayerCam()
        {
            cutscenePlaying = false;
            playerObject.gameObject.SetActive(true);
        }
    }
}



namespace BubbleWubble
{
    using TMPro;
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
        [Tooltip("The box for showing dialogue text.")]
        private TextMeshProUGUI dialogueBox;

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
                BubbleGame.Instance.GetHubCharacter().gameObject.SetActive(false);

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
            BubbleGame.Instance.GetHubCharacter().gameObject.SetActive(true);
        }

        /// <summary>
        /// Write text to the cutscene dialogue box.
        /// </summary>
        /// <param name="txt">String to write.</param>
        public void WriteText(string txt)
        {
            if (dialogueBox != null)
            {
                dialogueBox.SetText(txt);
            }
        }
    }
}



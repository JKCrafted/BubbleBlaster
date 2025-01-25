namespace BubbleWubble
{
    using AYellowpaper.SerializedCollections;
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

        [SerializeField]
        [Tooltip("Link minigame enum to animation string.")]
        private SerializedDictionary<BubbleGame.MinigameType, string> minigameCutscenes = new SerializedDictionary<BubbleGame.MinigameType, string>();

        /// <summary>
        /// Remember what cutscenes we've played
        /// </summary>
        private static SerializedDictionary<BubbleGame.MinigameType, bool> playedCutscenes = new SerializedDictionary<BubbleGame.MinigameType, bool>();

        /// <summary>
        /// Is a cutscene playing right now?
        /// </summary>
        bool cutscenePlaying = false;

        private void Start()
        {
            BubbleGame.Instance.LinkCutsceneSystem(this);
        }

        /// <summary>
        /// Play a minigame's finished cutscene.
        /// </summary>
        /// <param name="minigameType">What minigame cutscene should we play?</param>
        public void PlayMinigameFinishedCutscene(BubbleGame.MinigameType minigameType)
        {
            if (minigameCutscenes.ContainsKey(minigameType) && !playedCutscenes.ContainsKey(minigameType))
            {
                PlayCutscene(minigameCutscenes[minigameType]);
                playedCutscenes.Add(minigameType, true);
            }
        }

        /// <summary>
        /// Play a cutscene, cut out gameplay.
        /// </summary>
        /// <param name="cutsceneID">String anim ID</param>
        public void PlayCutscene(string cutsceneID)
        {
            if (!cutscenePlaying)
            {
                cutsceneAnimator.Play(cutsceneID);

                cutscenePlaying = true;
            }
        }

        public void DisablePlayerControl()
        {
            BubbleGame.Instance.GetHubCharacter().SetInControl(false);
        }

        public void DisablePlayerCamera()
        {
            BubbleGame.Instance.GetHubCharacter().gameObject.SetActive(false);
        }

        /// <summary>
        /// Give the player their camera back.
        /// </summary>
        public void RestorePlayerCam()
        {
            cutscenePlaying = false;
            BubbleGame.Instance.GetHubCharacter().gameObject.SetActive(true);
        }

        public void RestorePlayerControl()
        {
            BubbleGame.Instance.GetHubCharacter().SetInControl(true);
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



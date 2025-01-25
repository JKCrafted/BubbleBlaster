namespace BubbleWubble
{
    using NUnit.Framework;
    using SUPERCharacter;
    using System.Collections.Generic;
    using UnityEngine;
    using UnityEngine.SceneManagement;

    /// <summary>
    /// Core game manager.
    /// </summary>
    public class BubbleGame : MonoBehaviour
    {
        /// <summary>
        /// Static instance to the game manager.
        /// </summary>
        public static BubbleGame Instance;

        /// <summary>
        /// The type of minigame.
        /// </summary>
        public enum MinigameType
        {
            Flappy,
            Snake,
            Asteroids
        }


        [SerializeField]
        private GameObject escapeMenu;

        [SerializeField]
        private HUBPlayer characterRef;

        private CutsceneSystem cutsceneSystem;

        /// <summary>
        /// Track what minigames we've tried/completed.
        /// </summary>
        private Dictionary<MinigameType, bool> attemptedMinigames = new Dictionary<MinigameType, bool>();

        /// <summary>
        /// Remember where the player first started so we can return them there.
        /// </summary>
        private Vector3 playerInitialPos;

        /// <summary>
        /// Awake, set up instance and make this not die when scene changes.
        /// </summary>
        private void Awake()
        {
            if (Instance != null)
            {
                Destroy(gameObject);
            }
            else
            {
                Instance = this;
                DontDestroyOnLoad(gameObject);
            }

            playerInitialPos = characterRef.transform.position;

        }

        /// <summary>
        /// Return to the hub world from a subworld.
        /// </summary>
        /// <param name="fromMinigame">What minigame are we coming from?</param>
        /// <param name="success">Did you win your minigame?</param>
        public void ReturnToHub(MinigameType fromMinigame, bool success = false)
        {
            if (SceneManager.GetActiveScene().buildIndex != 0)
            {
                SceneManager.LoadScene(0);
                characterRef.gameObject.SetActive(true);

                Cursor.lockState = CursorLockMode.Locked;
                Cursor.visible = false;

                if (!attemptedMinigames.ContainsKey(fromMinigame))
                {
                    attemptedMinigames.Add(fromMinigame, success);
                }
                else
                {
                    attemptedMinigames[fromMinigame] = success;
                }
            }
        }

        /// <summary>
        /// Unity Update() Debug stuff.
        /// </summary>
        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.C))
            {
                cutsceneSystem.PlayCutscene("cs_test");
            }

            if (Input.GetKeyDown(KeyCode.Escape))
            {
                ShowHideEscapeMenu(!escapeMenu.gameObject.activeSelf);
            }
        }

        /// <summary>
        /// Show the menu that will allow the player to quit. Shows and unlocks cursor.
        /// </summary>
        /// <param name="isShown">True if shown, false if not.</param>
        public void ShowHideEscapeMenu(bool isShown)
        {
            Cursor.lockState = isShown ? CursorLockMode.Confined : CursorLockMode.Locked;
            characterRef.SetInControl(!isShown);
            Cursor.visible = isShown;
            escapeMenu.gameObject.SetActive(isShown);
        }
            
        /// <summary>
        /// What do you think this does?
        /// </summary>
        public void QuitGame()
        {
            Application.Quit();
        }

        /// <summary>
        /// Switch to a new scene given an index. Note this object will persist.
        /// </summary>
        /// <param name="sceneID">Scene ID in the build hierarchy.</param>
        public void SwitchScene(int sceneID)
        {
            if (sceneID > 0)
            {
                characterRef.gameObject.SetActive(false);
                characterRef.transform.position = playerInitialPos;
            }

            SceneManager.LoadScene(sceneID);
        }

        /// <summary>
        /// Get a reference to the hub player character.
        /// </summary>
        /// <returns>Ref to hub player character</returns>
        public HUBPlayer GetHubCharacter()
        {
            return characterRef;
        }

        /// <summary>
        /// Get a dictionary of completed minigames.
        /// </summary>
        /// <returns>Dictionary of <Minigame, Completed></returns>
        public Dictionary<MinigameType, bool> GetAttemptedMinigames()
        {
            return attemptedMinigames;
        }

        public void LinkCutsceneSystem(CutsceneSystem sys)
        {
            cutsceneSystem = sys;
        }
    }
}



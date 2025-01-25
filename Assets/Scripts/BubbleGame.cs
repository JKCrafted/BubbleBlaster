namespace BubbleWubble
{
    using SUPERCharacter;
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

        [SerializeField]
        [Tooltip("A ref to the HUB scene's custscene system")]
        private CutsceneSystem cutsceneSystem;

        [SerializeField]
        private GameObject escapeMenu;

        [SerializeField]
        private SUPERCharacterAIO characterRef;

        /// <summary>
        /// Awake, set up instance and make this not die when scene changes.
        /// </summary>
        private void Awake()
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }

        /// <summary>
        /// Return to the hub world from a subworld.
        /// </summary>
        /// <param name="success">Did you win your minigame?</param>
        public void ReturnToHub(bool success = false)
        {
            if (SceneManager.GetActiveScene().buildIndex != 0)
            {
                SceneManager.LoadScene(0);
                characterRef.gameObject.SetActive(true); 
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
            characterRef.enabled = !isShown;
            Cursor.lockState = isShown ? CursorLockMode.Confined : CursorLockMode.Locked;

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
            }

            SceneManager.LoadScene(sceneID);
        }
    }
}



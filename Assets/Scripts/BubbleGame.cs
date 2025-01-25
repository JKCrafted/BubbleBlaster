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

        public void ShowHideEscapeMenu(bool isShown)
        {
            characterRef.enabled = !isShown;
            escapeMenu.gameObject.SetActive(isShown);
        }

        public void QuitGame()
        {
            Application.Quit();
        }
    }
}



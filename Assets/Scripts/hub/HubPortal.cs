namespace BubbleWubble
{
    using System.Collections;
    using UnityEngine;
    using UnityEngine.UI;

    /// <summary>
    /// The portal into the minigames from the HUB.
    /// </summary>
    public class HubPortal : MonoBehaviour
    {
        [SerializeField]
        [Tooltip("Scene ID from build hierarchy")]
        private int sceneToLoad;
        public Color color;
        public GameObject fade;

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
                    StartCoroutine(LoadingScene(color, 1.5f));
                    
                }
            }
        }

        IEnumerator LoadingScene(Color colour, float speed)
        {
            GameObject newFade = Instantiate(fade);
            newFade.transform.SetParent(transform);
            FadeEffect fadeEffect = newFade.GetComponent<FadeEffect>();
            fadeEffect.gameObject.transform.GetChild(0).GetComponent<Image>().color = colour;
            fadeEffect.fadingSpeed = speed;
            yield return new WaitForSeconds(speed+0.1f);
            BubbleGame.Instance.SwitchScene(sceneToLoad);
        }

        //IEnumerator SceneTransition()
        //{

        //     yield return new WaitForSeconds(1);
        // }


    }
}



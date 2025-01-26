namespace BubbleWubble
{
    using UnityEngine;

    public class BubbleGunCollider : MonoBehaviour
    {
        [SerializeField]
        private CutsceneSystem cutsceneSystem;

        [SerializeField]
        private GameObject bubbleGunObject;

        private bool collected = false;

        private void OnTriggerEnter(Collider other)
        {
            if (!collected)
            {
                if (other.tag.Equals("Player"))
                {
                    bubbleGunObject.SetActive(false);
                    cutsceneSystem.PlayCutscene("cs_gunpickedup");
                }
            }
        }
    }
}



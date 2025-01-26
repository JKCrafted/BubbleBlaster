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
                    collected = true;
                    other.transform.GetChild(0).gameObject.AddComponent<GunRaycast>();
                    bubbleGunObject.SetActive(false);
                    cutsceneSystem.PlayCutscene("cs_gunpickedup");
                    other.transform.GetChild(1).gameObject.SetActive(true);
                }
            }
        }
    }
}



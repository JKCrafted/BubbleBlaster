namespace BubbleWubble
{
    using UnityEngine;

    public class HubManager : MonoBehaviour
    {

        //public GameObject 

        private void Start()
        {
            var completedGames = BubbleGame.Instance.GetAttemptedMinigames();
        }
    }
}




using BubbleWubble;
using UnityEngine;

namespace Asteriod
{
    public class AsteroidGameManager : MonoBehaviour
    {
        public int player_score;
        public GameObject score_ui;
        public float gameTime = 60f; // Set the game time to 60 seconds
        public GameObject timer_ui; // UI element to display when the player wins
        public int shields = 1;
        private EndState endState;

        public GameObject enemyShip;
        bool enemyShipSpawned = false;


        public GameObject shield_ui;

        // Start is called once before the first execution of Update after the MonoBehaviour is created
        void Start()
        {
            endState = FindFirstObjectByType<EndState>();

            updateScore(0);
        }

        // Update is called once per frame
        void Update()
        {

            if(shields <= 0)
            {
                checkWinCondition();
            }

            gameTime -= Time.deltaTime;

            if (timer_ui != null)
            {
                timer_ui.GetComponent<TMPro.TextMeshProUGUI>().text = "Time: " + gameTime;
            }

            if (gameTime <= 0)
            {
                gameTime = 0;
                checkWinCondition();
            }

            if (gameTime > 1 && gameTime <= 30 && enemyShipSpawned == false) {
                
                Instantiate(enemyShip, new Vector3(150, 50, 50), Quaternion.identity);
                enemyShipSpawned = true;
            }

        }

        // take damage
        public void takeDamage(int damage)
        {
            shields -= damage;
            // if isset shield_ui
            if (shield_ui != null) {
                shield_ui.GetComponent<TMPro.TextMeshProUGUI>().text = "Shields: " + shields;
            }
            
            checkWinCondition();

        }

        public void updateScore(int score)
        {
            player_score += score;
            // update ui textmesh pro

            score_ui.GetComponent<TMPro.TextMeshProUGUI>().text = "Score: " + player_score;
        }

        public void setScore(int score)
        {
            player_score = score;
            // update ui textmesh pro
            score_ui.GetComponent<TMPro.TextMeshProUGUI>().text = "Score: " + player_score;
        }

        private void checkWinCondition()
        {
            if (isGameOver())
            {
                Debug.Log("YOU WIN!");
                endState.winThreshold = true;
                endState.GameEnd();
                // Add any additional win logic here
            }
            else {
                Debug.Log("YOU LOSE!");
                endState.winThreshold = false;
                endState.GameEnd();
                // Add any additional lose logic here
            }
        }

        public void restartGame() {
            // destroy all asteroids under bubble machine
            // get the bubble machine and reset it
            GameObject bubbleMachine = GameObject.Find("BubbleMachine");
            foreach (Transform child in bubbleMachine.transform) {
                Destroy(child.gameObject);
            }
            // reset player position
            GameObject player = GameObject.Find("BubbleShip");
            player.transform.position = new Vector3(0, 0, 0);

            // find all bullets taged Bullet and destroy them
            GameObject[] bullets = GameObject.FindGameObjectsWithTag("Bullet");
            foreach (GameObject bullet in bullets) {
                Destroy(bullet);
            }
            // reset player score
            setScore(0);
            // reset player shields
            shields = 1;
            takeDamage(0);
            // reset game time
            gameTime = 60f;

            // spawn new asteroids
            bubbleMachine.GetComponent<BubbleMachine>().spawnAsteroids();
        }

        public bool isGameOver() {
            if (shields > 0 && player_score >= 50) {
                return true;
            } else {
                return false;
            }
        }
    }
}
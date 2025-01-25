using UnityEngine;

namespace Flappy
{
    public class PillarController : MonoBehaviour
    {
        private float pillarSpeed = 1f;
        [SerializeField] private float xBound = -15f;
        private FlappyGameManager gameManager;
        private SpawnManager spawnManager;

        void Start()
        {
            // rigidbody = GetComponent<Rigidbody>();
            gameManager = GameObject.Find("FlappyGameManager").GetComponent<FlappyGameManager>();
            spawnManager = GameObject.Find("SpawnManager").GetComponent<SpawnManager>();
            Randomise();


        }
        private void Update()
        {
            pillarSpeed = gameManager.pillarSpeed;
            Debug.Log(pillarSpeed);
            this.transform.position -= Vector3.right * pillarSpeed * Time.deltaTime;

            if (this.transform.position.x < xBound)
            {
                Destroy(this.gameObject);
            }
        }

        private void Randomise()
        {
            int randomIndex = Random.Range(1, 8); // Randomly pick a block between 1 and 8
            Debug.Log(randomIndex);

            float emptySpacePosition = 0f;
            if (randomIndex == 1)
            {
                emptySpacePosition = 0.45f;
            }
            else if (randomIndex == 2)
            {
                emptySpacePosition = 0.35f;
            }
            else if (randomIndex == 3)
            {
                emptySpacePosition = 0.25f;
            }
            else if (randomIndex == 4)
            {
                emptySpacePosition = 0.15f;
            }
            else if (randomIndex == 5)
            {
                emptySpacePosition = 0.05f;
            }
            else if (randomIndex == 6)
            {
                emptySpacePosition = -0.05f;
            }
            else if (randomIndex == 7)
            {
                emptySpacePosition = -0.15f;
            }
            else if (randomIndex == 8)
            {
                emptySpacePosition = -0.25f;
            }

            // Transform block1 = transform.GetChild(randomIndex);
            // Transform block2 = transform.GetChild(randomIndex + 1);
            // Transform block3 = transform.GetChild(randomIndex + 2);
            Transform block1 = transform.GetChild(1);
            Transform block2 = transform.GetChild(2);

            if (block1 != null && block2 != null)
            {
                // float emptySpacePosition = (randomIndex - 3.5f)* 0.1f;

                block1.localPosition = new Vector3(block1.localPosition.x, 0.5f + emptySpacePosition, block1.localPosition.z);
                block2.localPosition = new Vector3(block2.localPosition.x, -0.5f + emptySpacePosition - 0.3f, block2.localPosition.z);

                // block1.gameObject.SetActive(false);
                // block2.gameObject.SetActive(false);
                // block3.gameObject.SetActive(false);
            }


        }

        private void OnCollisionEnter(Collision collision)
        {
            Debug.Log("Collided with pillar!");
            gameManager.GameOver();
        }

        private void OnTriggerExit(Collider other)
        {
            
                gameManager.UpdateScore(1);
                gameManager.pillarSpeed += 0.1f;
                if (spawnManager.spawnInterval > 1f) {

                    spawnManager.spawnInterval -= 0.06f;
                }
            
        }
    }
}
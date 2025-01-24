using UnityEngine;

public class PillarController : MonoBehaviour
{
    public float speed;
    public float xBound;

    void Start()
    {
        // rigidbody = GetComponent<Rigidbody>();
        Randomise();
        
    }
    private void Update()
    {
        this.transform.position -= Vector3.right * speed * Time.deltaTime;

        if (this.transform.position.x < xBound)
        {
            Destroy(this.gameObject);
        }
    }

    private void Randomise()
    {
        int randomIndex = Random.Range(1, 8); // Randomly pick a block between 1 and 8

        Transform block1 = transform.GetChild(randomIndex);
        Transform block2 = transform.GetChild(randomIndex + 1);
        Transform block3 = transform.GetChild(randomIndex + 2);

        if (block1 != null && block2 != null)
        {
            block1.gameObject.SetActive(false);
            block2.gameObject.SetActive(false);
            block3.gameObject.SetActive(false);
        }

        
    }

    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log("Collided with pillar!");
    }
}

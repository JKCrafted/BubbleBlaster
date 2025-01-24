using UnityEngine;

public class BulletController : MonoBehaviour
{

    [SerializeField]
    float bullet_speed = 10f;

    Rigidbody rb;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {

        Vector3 current_pos = transform.position;

        if (current_pos.x < -75 || current_pos.x > 75 || current_pos.y < -75 || current_pos.y > 75)
        {
            Destroy(this.gameObject);
        }

        current_pos += transform.forward * bullet_speed * Time.deltaTime;

        transform.position = current_pos;
    }


    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Asteroid")
        {
            Destroy(this.gameObject );
        }
    }
}

using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public GameObject player;
    public GameObject bullet;
    public float speed = 5f;
    public float delay = 2f;
    public float bulletSpeed = 10f;
    public float enemyLifeLength = 30f;

    public AudioClip shooting_sound;
    public AudioSource audio_source;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        player = GameObject.Find("BubbleShip");
        Debug.Log("BubbleShip: " + player);
    }

    // Update is called once per frame
    void Update()
    {
        transform.LookAt(player.transform);
        transform.position = Vector3.MoveTowards(transform.position, player.transform.position, speed * Time.deltaTime);

        if (Time.time > delay)
        {
            audio_source.PlayOneShot(shooting_sound);
            GameObject gun = GameObject.FindWithTag("EnemyShipGun");
            Instantiate(bullet, gun.transform.position, gun.transform.rotation);
            delay = Time.time + 2f;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Bullet")
        {
            Destroy(gameObject);
        }
    }
}

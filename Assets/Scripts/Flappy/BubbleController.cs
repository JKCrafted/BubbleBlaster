using System;
using UnityEngine;

namespace Flappy
{
    public class BubbleController : MonoBehaviour
    {
        private Rigidbody rigidbody;
        [SerializeField] private float force;

        public AudioSource audio_source;
        public AudioClip flappy_falling_sound;

        private void Start()
        {
            rigidbody = GetComponent<Rigidbody>();
        }

        private void Flap()
        {
            rigidbody.linearVelocity = Vector3.zero;
            Vector3 current_pos = transform.position;
            current_pos += transform.up * force * Time.deltaTime;
            transform.position = current_pos;
        }
        private void Update()
        {
            if (Input.GetKey(KeyCode.Space))
            {
                Flap();
                // audio_source.PlayOneShot(flappy_rising_sound);
            }
            else
            {
                audio_source.PlayOneShot(flappy_falling_sound);
            }
        }

        // private void OnCollisionEnter(Collision collision)
        // {
        //     gameManager.GameOver();
        // }

    }
}
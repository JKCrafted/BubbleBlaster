using System;
using UnityEngine;

public class BubbleController : MonoBehaviour
{
    private Rigidbody rigidbody;
    [SerializeField] private float force;

    private void Start()
    {
        rigidbody = GetComponent<Rigidbody>();

    }

    private void Update()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            Flap();
        }
    }

    private void Flap()
    {
        rigidbody.linearVelocity = Vector3.zero;
        Vector3 current_pos = transform.position;
        current_pos += transform.up * force * Time.deltaTime;
        transform.position = current_pos;
    }

    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log("Game Over!");
    }

}
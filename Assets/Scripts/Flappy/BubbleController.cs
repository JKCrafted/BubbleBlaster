using System;
using UnityEngine;

public class BubbleController : MonoBehaviour
{
    private Rigidbody rigidbody;
    public float force;


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
        rigidbody.AddForce(Vector3.up * force, ForceMode.Impulse);
    }

    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log("Game Over!");
    }

}
using System;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody rigidbody;

    [SerializeField]
    public float speed = 15f;

    public float pitch_speed = 100f;

    public float yaw_speed = 100f;

    Vector3 velocity;

    void Start()
    {
        rigidbody = GetComponent<Rigidbody>();
        
    }

    void Update()
    {
        float hor_input = Input.GetAxis("Horizontal");
        float ver_input = Input.GetAxis("Vertical");

        Debug.Log("Vertical" + ver_input);
        Debug.Log("Horizontal" + hor_input);


        Vector3 current_pos = transform.position;

        current_pos += transform.forward*speed*Time.deltaTime;
        //current_pos += (transform.right * hor_input) * speed * Time.deltaTime;
        //current_pos += (transform.up * ver_input) * speed * Time.deltaTime;

        transform.position = current_pos;

        Vector3 rotation = transform.rotation.eulerAngles;

        //rotation.x += ver_input * speed * Time.deltaTime;
        
        //transform.rotation = Quaternion.Euler(rotation);

        //rotation.y += hor_input * turning_speed * Time.deltaTime;
        //transform.rotation = Quaternion.Euler(rotation);

        float pitchDelta = ver_input * pitch_speed * Time.deltaTime;
        float yawDelta = hor_input * yaw_speed * Time.deltaTime;

        transform.rotation *= Quaternion.Euler(pitchDelta, yawDelta, 0);


    }
}

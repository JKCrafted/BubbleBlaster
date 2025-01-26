using UnityEngine;

public class SetGunPosition : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //Debug.Log(transform.parent.GetChild(0).forward);
        Vector3 newPosition = transform.parent.GetChild(0).position + transform.parent.GetChild(0).forward; 
        transform.position = newPosition;
        Quaternion newRotation = transform.parent.localRotation;
        newRotation.y += 90f;

        transform.localRotation = newRotation;
    }
}

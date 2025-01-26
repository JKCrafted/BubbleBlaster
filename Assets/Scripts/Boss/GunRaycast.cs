using UnityEngine;

public class GunRaycast : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    LayerMask layerMask = LayerMask.GetMask("Wall", "Character");

    // See Order of Execution for Event Functions for information on FixedUpdate() and Update() related to physics queries
    void FixedUpdate()
    {

        RaycastHit hit;
        // Does the ray intersect any objects excluding the player layer
        if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out hit, Mathf.Infinity, layerMask))

        {   

            if (hit.transform.gameObject.tag.Contains("BadGuy"))
            {
                Debug.Log("Do ending");
            }

            //Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.forward) * hit.distance, Color.yellow);
            //Debug.Log("Did Hit");
        }

    }
}

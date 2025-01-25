using UnityEngine;

public class Raycasting : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hitData_for_the_ray;
        if (Physics.Raycast(ray, out hitData_for_the_ray))
        {
            //Debug.Log(hitData_for_the_ray);
            

        }
    }
}

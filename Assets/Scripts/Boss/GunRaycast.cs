using BubbleWubble;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunRaycast : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    [SerializeField]
    private CutsceneSystem cutsceneSystem;

    // See Order of Execution for Event Functions for information on FixedUpdate() and Update() related to physics queries
    void FixedUpdate()
    {

        RaycastHit hit;
        // Does the ray intersect any objects excluding the player layer
        if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out hit, Mathf.Infinity))

        {
            Debug.Log(hit.transform.gameObject.name);
            if (hit.transform.gameObject.tag.Contains("BadGuy"))
            {
                GameObject enemy = hit.transform.gameObject;
                while (true)
                {
                    if (enemy.transform.parent.tag.Contains("BadGuy"))
                    {
                        enemy = enemy.transform.parent.gameObject;
                    }
                    else
                    {
                        break;
                    }
                }
                enemy.transform.GetChild(enemy.transform.childCount - 1).gameObject.SetActive(true);
                StartCoroutine(EnemyFly(enemy));

                //cutsceneSystem.PlayCutscene("cs_endingcutscene");

                Debug.Log("Do ending");
            }

            //Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.forward) * hit.distance, Color.yellow);
            //Debug.Log("Did Hit");
        }

    }

    IEnumerator EnemyFly(GameObject enemy)
    {
        yield return new WaitForSeconds(5);
        enemy.AddComponent<Rigidbody>();
        enemy.GetComponent<Rigidbody>().useGravity = false;
        enemy.GetComponent<Rigidbody>().AddForce(Vector3.up);
        enemy.GetComponent<Rigidbody>().AddForce(Vector3.up);
        enemy.GetComponent<Rigidbody>().AddForce(Vector3.up);
        enemy.GetComponent<Rigidbody>().AddForce(Vector3.up);
    }

}

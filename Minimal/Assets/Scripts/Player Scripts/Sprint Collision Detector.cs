using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SprintCollisionDetector : MonoBehaviour
{
    public GameObject player;
    public GameObject hitboxLocation;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        player.GetComponent<ISprint>().OnSprintHit();
    }

    void FixedUpdate()
    {
        transform.position = hitboxLocation.transform.position;
        transform.rotation = hitboxLocation.transform.rotation;
    }

    void OnTriggerEnter(Collider other)
    {
        Debug.Log("collided with " + other.gameObject.name + "with tag " + other.gameObject.tag);
        if(other.gameObject.CompareTag("Wall"))
        {
            player.GetComponent<ISprint>().OnSprintHit();
        }
    }
}

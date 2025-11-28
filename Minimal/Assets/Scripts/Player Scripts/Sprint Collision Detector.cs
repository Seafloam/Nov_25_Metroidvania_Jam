using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SprintCollisionDetector : MonoBehaviour
{
    public GameObject player;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.CompareTag("Wall"))
        {
            player.GetComponent<ISprint>().OnSprintHit();
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlamCollisionDetector : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.GetComponent<ISlammable>() != null)
        {
            Debug.Log(other.name);
            other.GetComponent<ISlammable>().OnSlam();
        }
    }
}

using UnityEngine;

public class SlammablePlatform : MonoBehaviour, ISlammable
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnSlam()
    {
        Destroy(gameObject);
    }
}

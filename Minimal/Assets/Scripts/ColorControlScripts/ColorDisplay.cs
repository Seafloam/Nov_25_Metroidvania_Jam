using UnityEngine;

public class ColorDisplay : MonoBehaviour
{
    public string DesignatedColor;
    public Material locked;
    public Material wire;
    public Material painted;
    public bool Wired;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        GetComponent<Renderer>().material = locked;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            print("E detected");
        }
    }

    public void Unlock()
    {
        GetComponent<Renderer>().material = wire;
        Wired = true;
    }

    private void OnTriggerEnter(Collider other)
    {
        
    }

  //This isnt working properly. Registering every button press but not actually changing the color
    private void OnTriggerStay(Collider other)
    {
        print("touching player");

        if (other.gameObject.tag == "Player" && Input.GetKeyDown(KeyCode.E))
        {
               GetComponent<Renderer>().material = painted;
            Wired = false;
        }
    }
}

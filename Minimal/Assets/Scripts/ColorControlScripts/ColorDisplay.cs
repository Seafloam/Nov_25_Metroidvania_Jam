using UnityEngine;

public abstract class ColorDisplay : MonoBehaviour
{
    public UnlockableColor DesignatedColor;
    public Material locked;
    public Material wire;
    public Material painted;
    public bool Wired;
    public bool PlayerDetected = false;
    Component[] ColorComponents;

    public abstract void Activated();
    public abstract void Deactivated();

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        GetComponent<Renderer>().material = locked;
    }

    // Update is called once per frame
    void Update()
    {
        if (PlayerDetected == true && Input.GetKeyDown(KeyCode.E))
        {
            SetColored(Wired);
        }
    }

    private void SetColored(bool colored)
    {
        if(colored)
        {
            GetComponent<Renderer>().material = painted;
            Wired = false;
            Activated();
        }
        else
        {
            GetComponent<Renderer>().material = wire;
            Wired = true;
            Deactivated();
        }
    }




    public void Unlock()
    {
        GetComponent<Renderer>().material = wire;
        Wired = true;
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            PlayerDetected = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            PlayerDetected = false;
        }
    }
}

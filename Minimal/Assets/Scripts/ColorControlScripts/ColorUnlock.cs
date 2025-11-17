using UnityEngine;

public class ColorUnlock : MonoBehaviour
{
    public GameObject colorcontroller;
    public ColorController ColorCtr;
    public string colorToUnlock;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        colorcontroller = GameObject.FindGameObjectWithTag("ColorController");
        ColorCtr = colorcontroller.GetComponent<ColorController>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision Other)
    {
        if(Other.gameObject.tag == "Player")
        {
            ColorCtr.UnlockColor(colorToUnlock);
            Destroy(this.gameObject);
        }
    }
}

using UnityEngine;

public class ColorController : MonoBehaviour
{
    GameObject[] colorObjects;
    ColorDisplay[] ColorDisplays;
    string[] designatedColor;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void UnlockColor(string color)
    {
        
        
        colorObjects = GameObject.FindGameObjectsWithTag("Color Object");

        ColorDisplays = new ColorDisplay[colorObjects.Length];
        designatedColor = new string[colorObjects.Length];

        for (int i = 0; i < colorObjects.Length; i++)
        {
            ColorDisplays[i] = colorObjects[i].GetComponent<ColorDisplay>();
            designatedColor[i] = ColorDisplays[i].DesignatedColor;

            for(int x = 0; x < ColorDisplays.Length; x++)
            {
                if(designatedColor[x] == color)
                {
                    ColorDisplays[x].Unlock();
                }
            }
        }
    }
}

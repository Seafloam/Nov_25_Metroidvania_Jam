using NUnit.Framework;
using System.Collections.Generic;
using System.Drawing;
using UnityEngine;
public enum UnlockableColor
{
    blue,
    red,
    green, 
    Invalid
}

public class ColorController : MonoBehaviour
{
    List<ColorDisplay>[] ColorDisplays = new List<ColorDisplay>[(int)UnlockableColor.Invalid];

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        GameObject[] colorObjects;
        colorObjects = GameObject.FindGameObjectsWithTag("Color Object");

        for(int i = 0; i < (int)UnlockableColor.Invalid; i++)
        {
            ColorDisplays[i] = new List<ColorDisplay>();
        }

        for (int i = 0; i < colorObjects.Length; i++)
        {
            UnlockableColor tempColor;
            ColorDisplay tempDisplay = colorObjects[i].GetComponent<ColorDisplay>();
            tempColor = tempDisplay.DesignatedColor;

            ColorDisplays[(int)tempColor].Add(tempDisplay);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void UnlockColor(UnlockableColor color)
    {
        List<ColorDisplay> currentColorList = ColorDisplays[(int)color];
        for (int i = 0; i < currentColorList.Count; i++)
        {
            currentColorList[i].Unlock();
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorMinigame : MonoBehaviour
{

    public ColorMarkerScript[] colorMarkerScripts;

    public Color destinedColor = Color.white;

    public float margineOfError = 20.0f;

    public MarkerEnabledScript markerEnabledScript;

    bool hasWon = false;

    public void Awake()
    {
        colorMarkerScripts = GetComponentsInChildren<ColorMarkerScript>();

        markerEnabledScript = GetComponentInChildren<MarkerEnabledScript>();
    }

    public void Update()
    {
        if (hasWon) return;

        Color color = new Color();
        int count = 0;

        for (int i = 0; i < colorMarkerScripts.Length; i++)
        {
            if(colorMarkerScripts[i].isSet)
            {
                count++;
                color += colorMarkerScripts[i].Color;
            }
        }

        if(count == colorMarkerScripts.Length)
        {
            if(Mathf.Abs(color.r - destinedColor.r) < margineOfError & Mathf.Abs(color.g - destinedColor.g) < margineOfError & Mathf.Abs(color.b - destinedColor.b) < margineOfError)
            {
                //win
                EndMenuScript.CompleteMinigame();
                hasWon = true;
                markerEnabledScript.Enable();
            }
            else
            {
                for (int i = 0; i < colorMarkerScripts.Length; i++)
                {
                    colorMarkerScripts[i].Reset();
                }
            }
        }
    }

    //stop 3

}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseMinigame : MonoBehaviour
{

    public BaseMarkerScript[] colorMultiplayerScripts = new BaseMarkerScript[5];

    private bool isSolved = false;

    private void Awake()
    {
        colorMultiplayerScripts = GetComponentsInChildren<BaseMarkerScript>();
    }

    void Update()
    {

        if (isSolved) return;

        bool isTrue = colorMultiplayerScripts[0].isSet & !colorMultiplayerScripts[1].isSet & !colorMultiplayerScripts[2].isSet &
            colorMultiplayerScripts[3].isSet & colorMultiplayerScripts[4].isSet;

        bool allSet = colorMultiplayerScripts[0].isSet & colorMultiplayerScripts[1].isSet & colorMultiplayerScripts[2].isSet &
            colorMultiplayerScripts[3].isSet & colorMultiplayerScripts[4].isSet;


        if (isTrue)
        {
            EndMenuScript.CompleteMinigame();

            for (int i = 0; i < colorMultiplayerScripts.Length; i++)
            {
                colorMultiplayerScripts[i].spriteColorAnimation.enabled = true;
                colorMultiplayerScripts[i].isSet = true;
            }

            isSolved = true;

            return;
        }

        if(allSet)
        {
            Reset();
        }
    }

    public void Reset()
    {
        for (int i = 0; i < colorMultiplayerScripts.Length; i++)
        {
            colorMultiplayerScripts[i].Reset();
        }
    }
}

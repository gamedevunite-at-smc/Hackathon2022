using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoffinMinigame : MonoBehaviour
{
    public CoffinSelection[] coffinSelectionScripts;

    private bool isSolved = false;

    private void Awake()
    {
        coffinSelectionScripts = GetComponentsInChildren<CoffinSelection>();
    }

    void Update()
    {

        if (isSolved) return;

        for (int i = 0; i < coffinSelectionScripts.Length; i++)
        {
            if(coffinSelectionScripts[i].isSet != true)
            {
                return;
            }
        }
        EndMenuScript.CompleteMinigame();

        isSolved = true;
    }
}

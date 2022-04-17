using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndMenuScript : MonoBehaviour
{
    private static new Animator animator;
    private static bool hasEnded = false;

    private void Awake()
    {
        animator = GetComponent<Animator>();
        hasEnded = false;
    }

    private void Update()
    {
        if(hasEnded)
        {
            AudioManager.DimAudio();

            if (Input.anyKeyDown)
            {
                Application.Quit();
            }
        }
    }

    public static void EndMenu()
    {
        animator.SetTrigger("FadeOut");
        hasEnded = true;
    }
}

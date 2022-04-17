using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FailedMenuScript : MonoBehaviour
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
        if (hasEnded)
        {
            AudioManager.DimAudio();

            if (Input.anyKeyDown)
            {
                animator.SetTrigger("FadeIn");
                hasEnded = false;
                //Respawn game.
                //We should turn off audio
                AudioManager.EnableAudio();

                StartMenuScript.RestartGame();
            }
        }
    }

    public static void EndMenu()
    {
        UnityEngine.Debug.Log("We ended");
        animator.SetTrigger("FadeOut");
        hasEnded = true;
    }
}

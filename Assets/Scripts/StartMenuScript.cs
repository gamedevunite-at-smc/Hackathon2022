using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartMenuScript : MonoBehaviour
{

    private static new Animator animator;
    private static bool isEnabled = true;
    private static bool isFirstFrame = true;
    private void Awake()
    {
        animator = GetComponent<Animator>();
    }

    private void Start()
    {
        PlayerScript.torchScript.holdBurn = true;
        PlayerScript.playerTransform.position = new Vector3(0, 0, 0);
        PlayerScript.torchScript.RefreshTimer();
        Camera.main.transform.position = new Vector3(0, 0, -10);

        isEnabled = true;
        isFirstFrame = true;
    }

    void Update()
    {
        if(Input.anyKeyDown & !isFirstFrame)
        {
            if(isEnabled) animator.SetTrigger("FadeIn");

            isEnabled = false;

            PlayerScript.torchScript.holdBurn = false;
        }

        if(isFirstFrame)
        {
            isFirstFrame = false;
        }
    }

    public static void RestartGame()
    {
        animator.SetTrigger("FadeOut");
        PlayerScript.torchScript.holdBurn = true;
        PlayerScript.playerTransform.position = new Vector3(0, 0, 0);
        PlayerScript.torchScript.RefreshTimer();
        Camera.main.transform.position = new Vector3(0, 0, -10);

        isEnabled = true;
        isFirstFrame = true;

    }
}

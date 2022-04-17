using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndMenuScript : MonoBehaviour
{
    private static new Animator animator;
    private static bool hasEnded = false;

    public static int finalMinigameCount = 5;
    public static int minigameCount = 0;

    private int index = 0;
    public static AudioClip[] finishedAudioClips;
    public AudioClip[] _finishedAudioClips;

    private void Awake()
    {
        animator = GetComponent<Animator>();
        hasEnded = false;

        finishedAudioClips = _finishedAudioClips;
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

    public static void CompleteMinigame()
    {
        minigameCount++;

        AudioSource.PlayClipAtPoint(finishedAudioClips[minigameCount % finishedAudioClips.Length], PlayerScript.playerTransform.position);

        if(minigameCount == finalMinigameCount)
        {
            EndMenu();
        }
    }
}

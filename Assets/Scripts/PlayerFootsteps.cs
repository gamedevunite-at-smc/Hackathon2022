using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class PlayerFootsteps : MonoBehaviour
{
    private AudioSource audioSource;

    private PlayerTileValue playerTileValue;

    public List<AudioClip> grassSoundClips;
    public List<AudioClip> rockSoundClips;

    private void Awake()
    {
        playerTileValue = GetComponentInParent<PlayerTileValue>();

        audioSource = GetComponent<AudioSource>();
    }

    public void Step()
    {
        var audioClip = playerTileValue.OnRoad ? PlayGrayClip() : PlayGreenClip();

        if(audioSource != null)
        {
            audioSource.PlayOneShot(audioClip);
        }
    }
    public AudioClip PlayGrayClip()
    {
        var index = Random.Range(0, rockSoundClips.Count);

        if (index < rockSoundClips.Count)
        {
            return rockSoundClips[index];
        }

        return null;
    }
    public AudioClip PlayGreenClip()
    {
        var index = Random.Range(0, grassSoundClips.Count);

        if(index < grassSoundClips.Count)
        {
            return grassSoundClips[index];
        }

        return null;
    }
}

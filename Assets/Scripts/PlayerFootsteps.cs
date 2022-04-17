using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class PlayerFootsteps : MonoBehaviour
{
    private new Transform transform;

    private Tilemap tilemap;

    private AudioSource audioSource;

    public AudioClip stepSound;

    public Color color;

    public List<Sprite> greyTiles;

    public List<AudioClip> grassSoundClips;
    public List<AudioClip> rockSoundClips;

    public Color grayColor;
    public Color greenColor;

    public Sprite sprite;

    private void Awake()
    {
        transform = GetComponent<Transform>();

        audioSource = GetComponent<AudioSource>();

        tilemap = FindObjectOfType<Tilemap>();
    }

    public void Step()
    {

        var cell = tilemap.WorldToCell(transform.position);

        sprite = tilemap.GetSprite(cell);

        var audioClip = greyTiles.Contains(sprite) ? PlayGrayClip() : PlayGreenClip();

        if(audioSource != null)
        {
            audioSource.PlayOneShot(audioClip);
        }
    }
    public AudioClip PlayGrayClip()
    {
        UnityEngine.Debug.Log("Play gray");

        var index = Random.Range(0, rockSoundClips.Count);

        if (index < rockSoundClips.Count)
        {
            return rockSoundClips[index];
        }

        return null;
    }
    public AudioClip PlayGreenClip()
    {
        UnityEngine.Debug.Log("Play green");

        var index = Random.Range(0, grassSoundClips.Count);

        if(index < grassSoundClips.Count)
        {
            return grassSoundClips[index];
        }

        return null;
    }
}

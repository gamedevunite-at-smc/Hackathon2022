using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioInstanceScript : MonoBehaviour
{

    private AudioSource audioSource;

    [SerializeField] private float speed = 2.0f;

    private float startingVolume;

    private void Awake()
    {
        audioSource = GetComponent<AudioSource>();
    }

    // Start is called before the first frame update
    void Start()
    {
        startingVolume = audioSource.volume;

        AudioManager.audioInstances.Add(this);
    }

    public void Dim()
    {
        StopAllCoroutines();

        StartCoroutine(LerpVolume(startingVolume / 5, 2));
    }

    public void Enable()
    {
        StopAllCoroutines();

        StartCoroutine(LerpVolume(startingVolume, 1));
    }

    public void Disable()
    {
        StopAllCoroutines();

        StartCoroutine(LerpVolume(0, 1));
    }

    private IEnumerator LerpVolume(float targetVolume, float dimMultipler)
    {

        float currentVolume = audioSource.volume;

        float time = 0;

        while(!Mathf.Approximately(audioSource.volume, targetVolume))
        {
            audioSource.volume = Mathf.SmoothStep(currentVolume, targetVolume, time);

            time += Time.deltaTime * speed * dimMultipler;

            yield return new WaitForEndOfFrame();
        }
    }

    private void OnDestroy()
    {
        AudioManager.audioInstances.Remove(this);
    }
}

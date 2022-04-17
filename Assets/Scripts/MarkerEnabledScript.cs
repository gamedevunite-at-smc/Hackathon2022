using Cainos.PixelArtTopDown_Basic;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MarkerEnabledScript : MonoBehaviour
{

    private SpriteRenderer spriteRenderer;

    private SpriteColorAnimation spriteColorAnimation;

    [SerializeField] private float enableTime = 1.0f;
    [SerializeField] private float intensityMultiplier = 1.0f;
    [SerializeField] private AnimationCurve intensityCurve = AnimationCurve.Linear(0, 0, 1, 1);
    [SerializeField] private AnimationCurve alphaCurve = AnimationCurve.Linear(0, 0, 1, 1);

    private void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        spriteColorAnimation = GetComponentInChildren<SpriteColorAnimation>();
    }

    private void Start()
    {
        spriteRenderer.enabled = false;
    }

    public void Enable()
    {
        spriteRenderer.enabled = true;

        spriteRenderer.material.SetFloat("_EmissionMultipler", 0);

        StartCoroutine(Glow());
    }

    public IEnumerator Glow()
    {
        spriteColorAnimation.run = false;

        var color = spriteRenderer.color;
        color.a = 0;
        spriteRenderer.color = color;
        spriteRenderer.enabled = true;

        float time = 0;
        float caluclatedPercent = 0;

        while (caluclatedPercent <= 1.0f)
        {
            caluclatedPercent = (time / enableTime);

            SetIntensity(intensityCurve.Evaluate(caluclatedPercent));

            color.a = alphaCurve.Evaluate(caluclatedPercent);
            spriteRenderer.color = color;

            time += Time.deltaTime;

            yield return new WaitForEndOfFrame();

        }

        spriteColorAnimation.run = true;

    }

    public void Reset()
    {
        
    }

    private void SetIntensity(float intensity)
    {
        spriteRenderer.material.SetFloat("_EmissionMultipler", intensityMultiplier * intensity);
    }
}

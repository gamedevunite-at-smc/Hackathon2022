using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.Rendering.Universal;
using System.Reflection;

public class LightTorchScript : MonoBehaviour
{

    private Light2D light2D;

    [Range(0.0f, 1f)]
    [SerializeField] private float intensityFalloffMultipler;
    [SerializeField] private AnimationCurve intensityFalloff = AnimationCurve.Linear(0, 0, 1, 1);

    [Range(0.0f, 25f)]
    [SerializeField] private float innerRadiusMultipler;
    [SerializeField] private AnimationCurve innerRadiusFalloff = AnimationCurve.Linear(0, 0, 1, 1);

    [Range(0.0f, 25f)]
    [SerializeField] private float outerRadiusMultipler;
    [SerializeField] private AnimationCurve outerRadiusFalloff = AnimationCurve.Linear(0, 0, 1, 1);

    [SerializeField] private Gradient gradient;
    [Range(0.0f, 1.0f)]
    [SerializeField] private float percent = 1.0f;

    public float Percent
    {
        set
        {

            percent = Mathf.Clamp01(value);

            light2D.color = gradient.Evaluate(percent);

            light2D.pointLightInnerRadius = innerRadiusMultipler * innerRadiusFalloff.Evaluate(percent);
            light2D.pointLightOuterRadius = outerRadiusMultipler * outerRadiusFalloff.Evaluate(percent);
            SetFalloff(intensityFalloffMultipler * intensityFalloff.Evaluate(percent));
        }
        get
        {
            return percent;
        }
    }

    private void Awake()
    {
        light2D = GetComponent<Light2D>();
    }

    private static FieldInfo m_FalloffField = typeof(Light2D).GetField("m_FalloffIntensity", BindingFlags.NonPublic | BindingFlags.Instance);

    public void SetFalloff(float falloff)
    {
        m_FalloffField.SetValue(light2D, falloff);
    }

    private void OnValidate()
    {
        if(light2D == null)
            light2D = GetComponent<Light2D>();

        Percent = percent;
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TorchScript : MonoBehaviour
{

    [SerializeField] private float maximumTourchTime = 100;
    [SerializeField] private float refillSpeed = 5;

    private float torchTime;

    private LightTorchScript lightTorchScript;

    private bool burnTorch = true;

    private void Awake()
    {
        lightTorchScript = GetComponentInChildren<LightTorchScript>();
    }

    private void Start()
    {
        torchTime = maximumTourchTime;
    }

    private void Update()
    {

        if (!burnTorch) return;

        torchTime -= Time.deltaTime;

        lightTorchScript.Percent = torchTime / maximumTourchTime;

        if (torchTime <= 0)
        {
            //We ran out of time!!
            //End game?
        }
    }

    public void RefreshTimer()
    {
        torchTime = maximumTourchTime;

        StartCoroutine(RefillTorch());
    }

    public IEnumerator RefillTorch()
    {
        float refillTimer = 0;
        float startingPercent = lightTorchScript.Percent;

        burnTorch = false;

        while (!Mathf.Approximately(lightTorchScript.Percent, 1.0f))
        {
            refillTimer += Time.deltaTime * refillSpeed;
            lightTorchScript.Percent = Mathf.SmoothStep(startingPercent, 1.0f, refillTimer);
            yield return new WaitForEndOfFrame();
        }

        burnTorch = true;
    }
}

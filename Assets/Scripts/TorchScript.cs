using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TorchScript : MonoBehaviour
{

    [SerializeField] private float maximumTourchTime = 100;

    private float torchTime;

    private LightTorchScript lightTorchScript;

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

        torchTime -= Time.deltaTime;

        lightTorchScript.Percent = torchTime / maximumTourchTime;

        if (torchTime <= 0)
        {
            //We ran out of time!!
        }
    }

    public void RefreshTimer()
    {
        torchTime = maximumTourchTime;
    }
}

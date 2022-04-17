using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour
{

    public static Transform playerTransform;
    public static TorchScript torchScript;

    private void Awake()
    {
        playerTransform = GetComponent<Transform>();
        torchScript = GetComponentInChildren<TorchScript>();
    }
}

using Cainos.PixelArtTopDown_Basic;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour
{

    public static Transform playerTransform;
    public static TorchScript torchScript;

    private float walkingSpeed = 2.0f;
    private float tileSpeed = 0.5f;

    private TopDownCharacterController characterControler;
    private PlayerTileValue playerTileValue;
    private void Awake()
    {
        playerTransform = GetComponent<Transform>();
        torchScript = GetComponentInChildren<TorchScript>();

        characterControler = GetComponent<TopDownCharacterController>();
        playerTileValue = GetComponent<PlayerTileValue>();
    }

    private void Update()
    {
        float speed = walkingSpeed;

        if (playerTileValue.OnRoad)
        {
            speed += tileSpeed;
        }

        characterControler.speed = speed;
    }
}

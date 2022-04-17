using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class CameraFollowScript : MonoBehaviour
{
    public float lerpSpeed = 1.0f;

    private Vector3 offset;

    private Vector3 targetPos;

    private void Start()
    {
        offset = transform.position - PlayerScript.playerTransform.position;
    }

    private void Update()
    {
        if (PlayerScript.playerTransform == null) return;

        targetPos = PlayerScript.playerTransform.position + offset;
        transform.position = Vector3.Lerp(transform.position, targetPos, lerpSpeed * Time.deltaTime);
    }

}

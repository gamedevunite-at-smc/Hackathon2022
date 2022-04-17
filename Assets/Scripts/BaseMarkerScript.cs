using Cainos.PixelArtTopDown_Basic;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseMarkerScript : MonoBehaviour
{
    [SerializeField] private float interactionDistance = 1.0f;

    private new Transform transform;

    private SpriteRenderer spriteRenderer;

    public SpriteColorAnimation spriteColorAnimation;

    public bool isSet = false;

    private void Awake()
    {
        transform = GetComponent<Transform>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        spriteColorAnimation = GetComponentInChildren<SpriteColorAnimation>();

        spriteColorAnimation.enabled = false;
        spriteRenderer.color = Color.white;
    }

    void Update()
    {
        if (isSet) return;

        if (Vector3.Distance(transform.position, PlayerScript.playerTransform.position) <= interactionDistance)
        {
            if (Input.GetKeyDown(KeyCode.Space) | Input.GetKeyDown(KeyCode.Return))
            {
                spriteColorAnimation.enabled = true;
                isSet = true;
            }
        }
    }

    public void Reset()
    {
        spriteColorAnimation.enabled = false;
        spriteRenderer.color = Color.white;
        isSet = false;
    }
}

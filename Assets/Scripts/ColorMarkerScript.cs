using Cainos.PixelArtTopDown_Basic;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorMarkerScript : MonoBehaviour
{
    [SerializeField] private float interactionDistance = 1.0f;

    private new Transform transform;

    private SpriteRenderer spriteRenderer;

    private SpriteColorAnimation spriteColorAnimation;

    public bool isSet = false;

    public Color Color => spriteRenderer.color;

    private void Awake()
    {
        transform = GetComponent<Transform>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        spriteColorAnimation = GetComponentInChildren<SpriteColorAnimation>();
    }

    void Update()
    {
        if (isSet) return;

        if (Vector3.Distance(transform.position, PlayerScript.playerTransform.position) <= interactionDistance)
        {
            if (Input.GetKeyDown(KeyCode.Space) | Input.GetKeyDown(KeyCode.Return))
            {
                spriteColorAnimation.enabled = false;
                isSet = true;
            }
        }
    }

    public void Reset()
    {
        spriteColorAnimation.enabled = true;
        isSet = false;
    }
}

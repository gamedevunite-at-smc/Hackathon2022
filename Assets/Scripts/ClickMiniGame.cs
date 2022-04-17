using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickMiniGame : MonoBehaviour
{
    [SerializeField] private float interactionDistance = 1.0f;

    private new Transform transform;

    private MarkerEnabledScript markerEnabledScript;

    private bool isPressed = false;

    private void Awake()
    {
        transform = GetComponent<Transform>();

        markerEnabledScript = GetComponentInChildren<MarkerEnabledScript>();
    }

    void Update()
    {
        if (isPressed) return;

        if (Vector3.Distance(transform.position, PlayerScript.playerTransform.position) <= interactionDistance)
        {
            if (Input.GetKeyDown(KeyCode.Space) | Input.GetKeyDown(KeyCode.Return))
            {
                markerEnabledScript.Enable();
                isPressed = true;

                EndMenuScript.CompleteMinigame();
            }
        }
    }
}

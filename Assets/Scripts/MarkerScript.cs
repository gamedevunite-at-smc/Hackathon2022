using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MarkerScript : MonoBehaviour
{
    [SerializeField] private float interactionDistance = 1.0f;

    private new Transform transform;

    private MarkerEnabledScript markerEnabledScript;

    private void Awake()
    {
        transform = GetComponent<Transform>();

        markerEnabledScript = GetComponentInChildren<MarkerEnabledScript>();
    }

    void Update()
    {
        if (Vector3.Distance(transform.position, PlayerScript.playerTransform.position) <= interactionDistance)
        {
            if (Input.GetKeyDown(KeyCode.Space) | Input.GetKeyDown(KeyCode.Return))
            {
                markerEnabledScript.Enable();
            }
        }
    }
}

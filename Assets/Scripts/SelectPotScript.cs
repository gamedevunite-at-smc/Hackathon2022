using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectPotScript : MonoBehaviour
{
    [SerializeField] private float interactionDistance = 1.0f;

    private new Transform transform;

    public bool hasBeenSelected = false;

    private void Awake()
    {
        transform = GetComponent<Transform>();
    }

    void Update()
    {
        if (hasBeenSelected) return;

        if (Vector3.Distance(transform.position, PlayerScript.playerTransform.position) <= interactionDistance)
        {
            if (Input.GetKeyDown(KeyCode.Space) | Input.GetKeyDown(KeyCode.Return))
            {
                EndMenuScript.CompleteMinigame();
            }
        }
    }
}

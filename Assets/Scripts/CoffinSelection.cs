using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoffinSelection : MonoBehaviour
{
    [SerializeField] private float interactionDistance = 1.0f;

    private new Transform transform;
    public bool isSet = false;

    private void Awake()
    {
        transform = GetComponent<Transform>();
    }

    void Update()
    {
        if (isSet) return;

        if (Vector3.Distance(transform.position, PlayerScript.playerTransform.position) <= interactionDistance)
        {
            if (Input.GetKeyDown(KeyCode.Space) | Input.GetKeyDown(KeyCode.Return))
            {
                isSet = true;
            }
        }
    }
}

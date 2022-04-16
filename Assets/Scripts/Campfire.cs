using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Campfire : MonoBehaviour
{

    [SerializeField] private float interactionDistance = 1.0f;

    private new Transform transform;

    private Transform playerTransform;

    private void Awake()
    {
        transform = GetComponent<Transform>();
    }

    void Update()
    {
        if(Vector3.Distance(transform.position, playerTransform.position) <= interactionDistance)
        {
            if(Input.GetKeyDown(KeyCode.Space))
            {
                //Refill TorchScript
            }
        }
    }
}

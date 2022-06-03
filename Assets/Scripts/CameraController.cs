using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField] private Transform targetTransform = null;
    private Vector3 offset;

    private void Start()
    {
        offset = transform.position - targetTransform.position;
    }

    private void LateUpdate() 
    {
        Vector3 newPosition = new Vector3(
            transform.position.x,
            transform.position.y,
            offset.z + targetTransform.position.z);

        transform.position = newPosition;

    }
}

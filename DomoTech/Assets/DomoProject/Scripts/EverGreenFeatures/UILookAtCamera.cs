using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UILookAtCamera : MonoBehaviour
{
    [SerializeField] private Camera mainCamera;

    private void LateUpdate()
    {
        Vector3 direction = (Camera.main.transform.position - transform.position).normalized;
        Quaternion lookRotation = Quaternion.LookRotation(-direction, Vector3.up);
        transform.rotation = lookRotation;
    }
}

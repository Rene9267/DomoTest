using Oculus.Interaction.Locomotion;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PushCameraAway : MonoBehaviour, ILocomotionEventBroadcaster
{
    [SerializeField] private HeadCollisionDetector headCollisionDetector;

    public event Action<LocomotionEvent> WhenLocomotionPerformed;

    private Vector3 CalculatePushBackDirection(List<RaycastHit> colliderHits)
    {
        Vector3 combinedNormal = Vector3.zero;
        foreach (RaycastHit hit in colliderHits)
        {
            combinedNormal += new Vector3(hit.normal.x, 0, hit.normal.z);
        }
        return combinedNormal;
    }
    private void Update()
    {
        if (headCollisionDetector.DetectedCollidersHit.Count <= 0)
        {
            return;
        }

        Vector3 pushBackDir = CalculatePushBackDirection(headCollisionDetector.DetectedCollidersHit);
        Vector3 newPosition = transform.position + pushBackDir * 0.3f;
        transform.position = newPosition;
    }
}

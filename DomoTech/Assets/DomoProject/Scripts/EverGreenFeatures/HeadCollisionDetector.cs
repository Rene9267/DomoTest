using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeadCollisionDetector : MonoBehaviour
{
    [SerializeField]
    private float detectionDelay = 0.05f;
    [SerializeField]
    private float detectionDistance = 0.2f;
    [SerializeField]
    private LayerMask detectionLayers;

    public List<RaycastHit> DetectedCollidersHit { get; private set; }

    private float currentTime = 0;

    private void Start()
    {
        DetectedCollidersHit = ColisionDetection(transform.position, detectionDistance, detectionLayers);
    }

    private void Update()
    {
        currentTime += Time.time;
        if (currentTime > detectionDelay)
        {
            currentTime = 0;
            DetectedCollidersHit = ColisionDetection(transform.position, detectionDistance, detectionLayers);
        }
    }

    private List<RaycastHit> ColisionDetection(Vector3 position, float distance, LayerMask mask)
    {
        List<RaycastHit> detectedHits = new();

        List<Vector3> directions = new() { transform.forward, transform.right, -transform.right };

        RaycastHit hit;
        foreach (var dir in directions)
        {
            if (Physics.Raycast(position, dir, out hit, distance, mask))
            {
                detectedHits.Add(hit);
            }
        }
        return detectedHits;
    }
}

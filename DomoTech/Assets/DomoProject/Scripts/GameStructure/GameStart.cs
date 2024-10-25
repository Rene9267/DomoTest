using System;
using UnityEngine;

public class GameStart : MonoBehaviour
{
    //evento gestito dal GameObserver
    public static event Action OnGameStarting;

    [SerializeField] private Animation customAnimation;

    private Collider startCollider;
    private bool isPlaying = false;

    private void Awake()
    {
        startCollider = GetComponent<Collider>();
    }

    //quando il player collide con il trigger parte animazione
    // e contemporaneamente parte il game
    private void OnCollisionEnter(Collision collision)
    {
        if (!isPlaying)
        {
            isPlaying = true;
            customAnimation.Play();
            OnGameStarting?.Invoke();
        }

    }
}

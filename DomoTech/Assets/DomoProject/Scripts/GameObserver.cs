using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

//deciso di procedere con un Observer in modo da evitare l'utilizzo di un signleton e tenrere il tutto più modulare e staccato possibile
public class GameObserver : MonoBehaviour
{
    public static event Action<int> IncrementPoints;

    private GameData data;

    private int collectedCound;

    private void Awake()
    {
        data = gameObject.GetComponent<GameData>();
    }

    private void OnEnable()
    {
        BaseCollectable.OnCollected += HandleCollectible;
    }

    private void OnDisable()
    {
        BaseCollectable.OnCollected -= HandleCollectible;
    }

    private void HandleCollectible()
    {
        collectedCound++;
        Debug.Log(collectedCound);
        IncrementPoints?.Invoke(collectedCound);
        if (collectedCound >= data.SpawnableItems)
        {
            EndGame();
        }
    }

    private void EndGame()
    {

    }
}

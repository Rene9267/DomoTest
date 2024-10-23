using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

//deciso di procedere con un Observer in modo da evitare l'utilizzo di un signleton e tenrere il tutto più modulare e staccato possibile
public class GameObserver : MonoBehaviour
{
    private float gameTime = 120;
    private float remainingTime;
    private int collectedCound;

    private void Start()
    {
        remainingTime = gameTime;
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
    }

    private void Update()
    {
        if (remainingTime > 0)
        {
            remainingTime -= Time.deltaTime;
        }
        else
        {
            remainingTime = gameTime;
            EndGame();
        }
    }

    private void EndGame()
    {

    }
}

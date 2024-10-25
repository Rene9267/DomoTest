using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.SceneManagement;

//deciso di procedere con un Observer in modo da evitare l'utilizzo di un signleton e tenrere il tutto più modulare e staccato possibile
public class GameObserver : MonoBehaviour
{
    // evento ascoltato da CollectableCounter
    public static event Action<int> OnIncrementPoints;
    //in ascolto da Timer, BaseCollectable
    public static event Action OnEndGame;

    [SerializeField] private GameObject restartButton;

    private GameData data;
    private Timer timer;
    private int collectedCount;

    private void Awake()
    {
        data = gameObject.GetComponent<GameData>();
        timer = gameObject.GetComponent<Timer>();
    }

    private void OnEnable()
    {
        BaseCollectable.OnCollected += HandleCollectible;
        GameStart.OnGameStarting += () => timer.IsStarting = true; //piccola lambda per evitare utilizzo di metodi superflui
        Timer.OnTimeEnd += EndGame;
    }

    private void OnDisable()
    {
        BaseCollectable.OnCollected -= HandleCollectible;
        GameStart.OnGameStarting -= () => timer.IsStarting = true;
        Timer.OnTimeEnd -= EndGame;
    }

    //quando un obj viene raccolto parte questo metodo
    // aumenta il count
    //chiama l'incrementro dei punti
    // e controlla se il game deve finire
    private void HandleCollectible()
    {
        collectedCount++;
        OnIncrementPoints?.Invoke(collectedCount);
        if (collectedCount >= data.SpawnableItems)
        {
            EndGame();
        }
    }

    //Quando il gioco finisce parte questo evento
    // inoltre si attiva il bottone per il restart
    private void EndGame()
    {
        restartButton.SetActive(true);
        OnEndGame?.Invoke();
    }

    // Facciamo ripartire la Scene
    public void RestartLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}

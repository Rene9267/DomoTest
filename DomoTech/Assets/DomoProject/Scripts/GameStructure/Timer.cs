using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Timer : MonoBehaviour
{
    //quando finsice il timer, controllato dal GameObserver
    public static event Action OnTimeEnd;

    [HideInInspector] public bool IsStarting = false;

    [SerializeField] private TextMeshProUGUI timerText;

    private GameData data;
    private float remainingTime;

    private void Awake()
    {
        data = gameObject.GetComponent<GameData>();
    }


    private void OnEnable()
    {
        GameObserver.OnEndGame += () => IsStarting = false;
    }

    private void OnDisable()
    {
        GameObserver.OnEndGame -= () => IsStarting = false;
    }

    private void Start()
    {
        remainingTime = data.GameTime;
        SetTextTimer();
    }

    private void Update()
    {
        //se il gioco è partito inizo a decrtementare il tempo 
        if (IsStarting)
        {
            if (remainingTime > 0)
            {
                remainingTime -= Time.deltaTime;
                SetTextTimer();
            }
            //altrimenti setto tutto a zero
            else
            {
                remainingTime = 0;
                SetTextTimer();
                IsStarting = false;
                OnTimeEnd?.Invoke();
            }
        }
    }

    private void SetTextTimer()
    {
        int minutes = Mathf.FloorToInt(remainingTime / 60);
        int seconds = Mathf.FloorToInt(remainingTime % 60);
        int milliseconds = Mathf.FloorToInt((remainingTime * 1000F) % 1000F);
        timerText.text = string.Format("{0:0}:{1:00}:{2:000}", minutes, seconds, milliseconds);
    }

}

using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Timer : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI timerText;

    private float gameTime = 120;
    private float remainingTime;
    private bool start = false;

    private void Start()
    {
        remainingTime = gameTime;
        int minutes = Mathf.FloorToInt(remainingTime / 60);
        int seconds = Mathf.FloorToInt(remainingTime % 60);
        int milliseconds = Mathf.FloorToInt((remainingTime * 1000F) % 1000F);
        timerText.text = string.Format("{0:0}:{1:00}:{2:000}", minutes, seconds, milliseconds);
    }
    private void Update()
    {
        if (start)
        {
            if (remainingTime > 0)
            {
                remainingTime -= Time.deltaTime;
                int minutes = Mathf.FloorToInt(remainingTime / 60);
                int seconds = Mathf.FloorToInt(remainingTime % 60);
                int milliseconds = Mathf.FloorToInt((remainingTime * 1000F) % 1000F);
                timerText.text = string.Format("{0:0}:{1:00}:{2:000}", minutes, seconds, milliseconds);
            }
            else
            {
                remainingTime = gameTime;
            }
        }
    }
}

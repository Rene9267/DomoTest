using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class CollectableCounter : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI timerText;
    [SerializeField] private GameData data;

    private void OnEnable()
    {
        GameObserver.IncrementPoints += UiUpdate;
    }

    private void OnDisable()
    {
        GameObserver.IncrementPoints -= UiUpdate;
    }

    private void Start()
    {
        timerText.text = string.Format("{0:0}/" + data.SpawnableItems, 0);
    }

    private void UiUpdate(int actualScore)
    {
        timerText.text = string.Format("{0:0}/" + data.SpawnableItems, actualScore);

    }
}

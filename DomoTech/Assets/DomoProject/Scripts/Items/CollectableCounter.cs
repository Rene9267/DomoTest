using TMPro;
using UnityEngine;

public class CollectableCounter : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI timerText;
    [SerializeField] private GameData data;

    private void OnEnable()
    {
        GameObserver.OnIncrementPoints += UiUpdate;
    }

    private void OnDisable()
    {
        GameObserver.OnIncrementPoints -= UiUpdate;
    }

    private void Start()
    {
        //setto il numero di obj raccolti a zero
        timerText.text = string.Format("{0:0}/" + data.SpawnableItems, 0);
    }

    private void UiUpdate(int actualScore)
    {
        //agiorno il contatore
        timerText.text = string.Format("{0:0}/" + data.SpawnableItems, actualScore);
    }
}

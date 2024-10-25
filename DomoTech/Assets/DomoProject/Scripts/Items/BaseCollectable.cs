using System;
using UnityEngine;

public class BaseCollectable : MonoBehaviour
{
    //Evento utilizzato dal GameObserver per tener traccia della raccolta
    public static event Action OnCollected;

    //controlla se siamo ancora in play
    private bool isEndGame = false;

    private void OnEnable()
    {
        GameObserver.OnEndGame += () => isEndGame = true;
    }
    private void OnDisable()
    {
        GameObserver.OnEndGame -= () => isEndGame = true;
    }

    //Quando raccolto l'oggetto si distrugge dopo aver chiamato l'evento
    public virtual void GrabItem()
    {
        if (!isEndGame)
        {
            OnCollected?.Invoke();
            Destroy(gameObject);
        }
    }

}

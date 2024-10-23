using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseCollectable : MonoBehaviour
{
    //Evento utilizzato dal GameObserver per tener traccia della raccolta
    public static event Action OnCollected;

    //Quando raccolto l'oggetto si distrugge dopo aver chiamato l'evento
    public void GrabItem()
    {
        OnCollected?.Invoke();
        Destroy(gameObject);
    }

}

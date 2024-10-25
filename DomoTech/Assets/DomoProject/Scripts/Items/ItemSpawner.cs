using UnityEngine;
public class ItemSpawner : MonoBehaviour
{
    [SerializeField] private GameObject BaseCollectable;
    [SerializeField] private GameData data;

    //Volume del box in cui spawnare gli obj
    private Vector3 volumeSize;
    private int maxAttempt = 2; //Numero di tentativi per lo spawn
    private Vector3 backUpPosition = new Vector3(0, 1, 0);

    private void Awake()
    {
        volumeSize = GetComponentInChildren<BoxCollider>().size;
    }

    void Start()
    {
        SafeSpawn();
    }

    //Spawner randomico sulla superfice di un cubo
    private void SafeSpawn()
    {
        for (int i = 0; i < data.SpawnableItems; i++)
        {
            Vector3 randomPosition;
            for (int y = 0; y < maxAttempt; y++)
            {
                //Calcolo la posizione randomica dell'interno del cubo
                randomPosition = new Vector3((Random.Range(-volumeSize.x, volumeSize.x) * 0.5f), 0, (Random.Range(-volumeSize.z, volumeSize.z) * 0.5f));

                //per controllare che gli obj non vengano spawnati tropo vicini ad altri utilizzo una CheckSpere
                if (!Physics.CheckSphere(randomPosition, 1f, 8))
                {
                    Instantiate(BaseCollectable, randomPosition, Quaternion.identity);
                    break;
                }
                //Se dovesse andar male e dopo due tentativi non riuscire a trovare posto creerò l'obj sovrapposto all'ultimo ma più in alto
                //in modo da evitare overlap
                Instantiate(BaseCollectable, randomPosition + backUpPosition, Quaternion.identity);
            }

        }

    }

}

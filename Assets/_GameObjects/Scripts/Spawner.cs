using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] GameObject prefabSpawned;
    [SerializeField] float spawnDelay;
    [SerializeField] int limitSpawned;
    private int n = 0;
    // Start is called before the first frame update
    void Start()
    {
     /*   while (n < limitSpawned)
        {
            n++;
            toSpawn();
        }*/
        //Invocar el método toSpawn(), en el segundo 0 en que se instacia el objeto en un intervalo entre spawn y spawn de spawnDelay segundos
        InvokeRepeating("toSpawn", 0, spawnDelay);
    }
    
    private void toSpawn()
    {
        n++;
        Instantiate(prefabSpawned, transform);
        transform.DetachChildren();
        if (n == limitSpawned)
        {
            CancelInvoke();
        }
    }
}

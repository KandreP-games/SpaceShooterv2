using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AreaSpawner : MonoBehaviour
{
    [SerializeField] GameObject prefabSpawned;
    [SerializeField] float spawnDelay;
    [SerializeField] int limitSpawned;
    [SerializeField] Transform upperLimit;
    [SerializeField] Transform lowerLimit;
    private int n = 0;
    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("ToSpawn", 0, spawnDelay);
    }
    
    private void ToSpawn()
    {
        float x = Random.Range(upperLimit.position.x, lowerLimit.position.x);
        float y = Random.Range(upperLimit.position.y, lowerLimit.position.y);
        float z = Random.Range(upperLimit.position.z, lowerLimit.position.z);
        n++;
        Instantiate(prefabSpawned, new Vector3(x,y,z), transform.rotation);
        transform.DetachChildren();
        if (n == limitSpawned)
        {
            CancelInvoke();
        }
    }
}

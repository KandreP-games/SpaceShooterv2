using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] GameObject prefabEnemy1;
    [SerializeField] GameObject prefabEnemy2;
    [SerializeField] Transform enemySpawner;
    [SerializeField] float spawnDelay;
    private int limitSpawned;
    private bool isSpawning = true;
    private int random;
    private int n;
    private void Start()
    {
        StartCoroutine("SpawnEnemies");
    }
    private void Update()
    {
        random = Random.Range(0, 2);
        limitSpawned = 1 * GameManager.waveNumber;
        if(n >= limitSpawned)
        {
            isSpawning = false;
        }
    }
    IEnumerator SpawnEnemies()
    {
        while (true)
        {
            if (isSpawning && random == 0)
            {
                Instantiate(prefabEnemy1, enemySpawner.position, enemySpawner.rotation);
                n++;
            }
            else if (isSpawning && random == 1)
            {
                Instantiate(prefabEnemy2, enemySpawner.position, enemySpawner.rotation);
                n++;
            }
            yield return new WaitForSeconds(spawnDelay);
        }
    }
    public void Restart()
    {
        isSpawning = true;
        n = 0;
    }
}

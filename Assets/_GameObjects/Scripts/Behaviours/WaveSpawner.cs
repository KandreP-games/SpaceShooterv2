using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveSpawner : MonoBehaviour
{
    public enum SpawnState { spawning, waiting, counting};
    [System.Serializable]
    public class Wave
    {
        public string name;
        public GameObject enemy1;
        public GameObject enemy2;
        public int count;
        public float spawnRate;
    }

    [SerializeField] Wave[] waves;
    private int nextWave = 0;
    public float timeBetweenWaves = 5f;
    public float waveCountDown;

    public float searchCountDown = 1f;
    private SpawnState state = SpawnState.counting;
    
    private void Start()
    {
        waveCountDown = timeBetweenWaves;
    }

    private void Update()
    {
 

        if (state == SpawnState.waiting)
        {
            //Check if enemies still alive
            if (!EnemyIsAlive())
            {
                //Start next wave countdown
                print("Wave completed");
                WaveCompleted();
            }
            else
            {
                return;
            }
        }
        if(waveCountDown <= 0)
        {
            if(state != SpawnState.spawning)
            {
                //Start spawning wave
                StartCoroutine(SpawnWave(waves[nextWave]));
            }
        }
        else
        {
            waveCountDown -= Time.deltaTime;
        }
    }

    IEnumerator SpawnWave(Wave _wave)
    {
        state = SpawnState.spawning;

        //Spawn the wave
        for(int i = 0; i<_wave.count; i++)
        {
            SpawnEnemy(_wave.enemy1);
            yield return new WaitForSeconds(1f / _wave.spawnRate);
        }

        state = SpawnState.waiting;
        yield break;
    }

    private void SpawnEnemy(GameObject _enemy)
    {
        //Spawn enemy
        print("Spawn enemy");
        Instantiate(_enemy, transform.position, transform.rotation);
    }

    private bool EnemyIsAlive()
    {
        searchCountDown -= Time.deltaTime;
        if(searchCountDown <= 0)
        {
            searchCountDown = 1f;
            if (GameObject.FindGameObjectWithTag("Enemy") == null)
            {
                return false;
            }
            
        }
        return true;
    }

    private void WaveCompleted()
    {
        
        state = SpawnState.counting;
        waveCountDown = timeBetweenWaves;

        if(nextWave >= waves.Length)
        {
            nextWave = 0;
            print("Completed all waves. Loop");
        }
        else
        {
            nextWave++;
        }

    }
}

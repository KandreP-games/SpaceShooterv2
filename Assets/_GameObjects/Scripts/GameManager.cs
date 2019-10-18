using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static bool isInside;
    private int numberEnemies;
    public static int  waveNumber = 1;
    private GameObject player;
    private int bioDomes;
    private GameObject[] spawners;
    private void Start()
    {
        numberEnemies = GameObject.FindGameObjectsWithTag("Enemy").Length;
        GameManager.isInside = false;
        player = GameObject.FindGameObjectWithTag("Player");
        bioDomes = GameObject.FindGameObjectsWithTag("EnemyObjective").Length;
        spawners = GameObject.FindGameObjectsWithTag("EnemySpawner");
    }

    private void Update()
    {
        StartCoroutine("Counter");
        if(player.GetComponent<Player1>().playerHp <= 0)
        {
            //DeathEvent();
            print("PlayerDeath");
        }

        if(bioDomes <= 0)
        {
            //DeathEvent();
            print("BioDomes Death");
        }
        
    }

    IEnumerator Counter()
    {
        numberEnemies = GameObject.FindGameObjectsWithTag("Enemy").Length;
        bioDomes = GameObject.FindGameObjectsWithTag("EnemyObjective").Length;
        while (numberEnemies <= 0)
        {
                waveNumber += 1;
                print("New Wave");
                for (int j = 0; j < spawners.Length; j++)
                {
                    spawners[j].GetComponent<Spawner>().Restart();
                }
        }
        
        yield return new WaitForSeconds(2);
    }

    public void DeathEvent()
    {
        SceneManager.LoadScene(2);
    }
}

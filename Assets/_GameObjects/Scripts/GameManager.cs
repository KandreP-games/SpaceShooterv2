using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static bool isInside;
    private int numberEnemies;
    public int waveNumber = 1;
    private void Start()
    {
        numberEnemies = GameObject.FindGameObjectsWithTag("Enemy").Length;
        GameManager.isInside = false;
    }

    private void Update()
    {
        StartCoroutine("EnemyCounter");
    }

    IEnumerator EnemyCounter()
    {
        numberEnemies = GameObject.FindGameObjectsWithTag("Enemy").Length;
        if(numberEnemies <= 0)
        {
            waveNumber += 1;
        }
        yield return null;
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static bool isInside;
    private GameObject player;
    private int bioDomes;


    private void Start()
    {
        GameManager.isInside = false;
        player = GameObject.FindGameObjectWithTag("Player");
        bioDomes = GameObject.FindGameObjectsWithTag("EnemyObjective").Length;
        StartCoroutine(FindEnemiesInScene());
    }

    private void Update()
    {
        if (player.GetComponent<Player1>().playerHp <= 0)
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

    IEnumerator FindEnemiesInScene()
    {
        
        yield return new WaitForSeconds(1);
    }
    public void DeathEvent()
    {
        SceneManager.LoadScene(2);
    }
}

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
    }

    private void Update()
    {
        if (player.GetComponent<Player1>().playerHp <= 0)
        {
            DeathEvent();
            print("PlayerDeath");
        }

        if(bioDomes <= 0)
        {
            DeathEvent();
            print("BioDomes Death");
        }
        
    }

    public void DeathEvent()
    {
        SceneManager.LoadScene(0);
    }
}

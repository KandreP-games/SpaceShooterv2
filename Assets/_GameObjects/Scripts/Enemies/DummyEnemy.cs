using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DummyEnemy : MobileEnemy
{
    private GameObject player;
    private GameObject[] EnemyObjective;
    private float distancePlayer;
    private float distanceNearHouse;
    [SerializeField] float fleeDistance;
    private void Start()
    {
        base.Start();
        player = GameObject.FindGameObjectWithTag("Player");
        EnemyObjective = GameObject.FindGameObjectsWithTag("EnemyObjective");
    }
    private void Update()
    {
        base.Update();
        EnemyPattern();
    }

    private void EnemyPattern()
    {
        distancePlayer = Vector3.Distance(player.transform.position, transform.position);
        for(int i = 0; i < EnemyObjective.Length; i++)
        {

        }
        if (distancePlayer < fleeDistance)
        {
            transform.rotation = player.transform.rotation;
        }
    }
}
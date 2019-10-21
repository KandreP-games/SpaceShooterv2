using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SmartEnemy : MobileEnemy
{
    private float distancePlayer;
    protected GameObject player;
    [SerializeField] float followDistance;
    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }
    void Update()
    {
        base.Update();
        FindTarget();
    }

    private void FindTarget()
    {
        target = player.transform.position;
    }
}

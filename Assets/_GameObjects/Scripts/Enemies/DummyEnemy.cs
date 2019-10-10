using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DummyEnemy : MobileEnemy
{
    private GameObject[] objectives;
    private void Start()
    {
        base.Start();
        objectives = GameObject.FindGameObjectsWithTag("EnemyObjective");
    }
}

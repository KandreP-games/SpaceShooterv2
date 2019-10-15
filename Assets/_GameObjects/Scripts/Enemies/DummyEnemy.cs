using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class DummyEnemy : MobileEnemy
{
    private GameObject[] objectives;
    private int j;
    private void Start()
    {
        base.Start();
        objectives = GameObject.FindGameObjectsWithTag("EnemyObjective");
    }
    private void Update()
    {
        base.Update();
        FindTarget();
        transform.LookAt(objectives[j].transform);
    }
    private void FindTarget()
    {
        List<float> distances = new List<float>();
        for (int i = 0; i < objectives.Length; i++)
        {
           distances.Add(Vector3.Distance(objectives[i].transform.position, transform.position));
        }
        j = distances.IndexOf(distances.Min());   
    }
    public void HouseDamage()
    {
        transform.Translate(0, 0, 0);

    }
}

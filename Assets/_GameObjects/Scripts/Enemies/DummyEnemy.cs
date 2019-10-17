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
        FindTarget();
    }
    private void Update()
    {
        base.Update();
        transform.LookAt(objectives[j].transform);
    }
    private void FindTarget()
    {
        // This function is to go to the nearest objective
        /*List<float> distances = new List<float>();
        for (int i = 0; i < objectives.Length; i++)
        {
           distances.Add(Vector3.Distance(objectives[i].transform.position, transform.position));
        }
        j = distances.IndexOf(distances.Min());*/
        //This other is to go to a random objective
         j = Random.Range(0, 3);
    }
    /*public void HouseDamage()
    {
        transform.Translate(0, 0, 0);

    }*/
}

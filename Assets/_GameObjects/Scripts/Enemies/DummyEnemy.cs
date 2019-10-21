
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class DummyEnemy : MobileEnemy
{
    private GameObject[] objectives;
    private int j;

    private bool isInsideDome = false;


    private void Start()
    {
        base.Start();
        objectives = GameObject.FindGameObjectsWithTag("EnemyObjective");
        target = GameObject.Find("EnemyTarget").transform.position;
    }
    private void Update()
    {
        base.Update();
        LookAtTarget();
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.name == "EnemyTarget")
        {
            FindTarget();
        }
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
        j = Random.Range(0, objectives.Length);
        target = objectives[j].transform.position;
    }
    public void ChangeDomeStatus()
    {
        isInsideDome = !isInsideDome;
        GetComponent<Rigidbody>().isKinematic = true;
    }
    public void ReferenceDome(GameObject gameObject)
    {
        touchingDome = gameObject;
    }
    private void OnDestroy()
    {
        if (isInsideDome)
        {
            touchingDome.GetComponent<BioDomeBehaviour>().OneLessEnemy();
        }
    }
}

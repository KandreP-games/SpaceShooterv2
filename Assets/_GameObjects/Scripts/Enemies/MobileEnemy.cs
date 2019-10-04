using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MobileEnemy : Enemies
{
    [SerializeField] float speed;
    private void Start()
    {
        base.Start();
        InvokeRepeating("toRotate", Random.Range(0.5f, 5), Random.Range(0.5f, 5));
    }
    private void Update()
    {
        toMove();
    }
    private void toMove()
    {
        transform.Translate(Vector3.forward * Time.deltaTime * speed);
    }   
    private void toRotate()
    {
        transform.Rotate(0, Random.Range(0, 360), 0);
    }
}

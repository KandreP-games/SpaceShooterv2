using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MobileEnemy : Enemies
{
    [SerializeField] float speed;
    [SerializeField] float timeBetweenRotation;
    private void Start()
    {
        base.Start();
    }
    public void Update()
    {
        toMove();
    }
    private void toMove()
    {
        transform.Translate(Vector3.forward * Time.deltaTime * speed);
    }   

}

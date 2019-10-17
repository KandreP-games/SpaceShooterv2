using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MobileEnemy : Enemies
{
    [SerializeField] float speed;
    [SerializeField] float timeBetweenRotation;
    [SerializeField] protected int damage;
    private void Start()
    {
        base.Start();
        Invoke("ToRotate", timeBetweenRotation);
    }
    protected void Update()
    {
        base.Update();
        ToMove();
    }
    protected void ToMove()
    {
        transform.Translate(Vector3.forward * Time.deltaTime * speed);
    }   
    protected void ToRotate()
    {
        if (estado != ESTADO.Siguiendo)
        {
            transform.Rotate(0, Random.Range(0, 360), 0);
        }
    }
    protected void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.name == "Player")
        {
            ToDie();
            collision.gameObject.GetComponent<Player1>().ChangeLife(damage);
        }
    }
}

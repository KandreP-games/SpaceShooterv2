using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MobileEnemy : Enemies
{
    [SerializeField] float speed;
    [SerializeField] protected int damage;
    private bool isMoving = true;
    
    protected GameObject touchingDome;
    protected Vector3 target;


    protected void Update()
    {
        base.Update();
        if (isMoving)
        {
            ToMove();
            LookAtTarget();
        }
        
    }
    protected void LookAtTarget()
    {
        transform.LookAt(target);

    }
    private void ToMove()
    {
        transform.position += transform.forward * speed * Time.deltaTime;
    }
    public void ToStop()
    {
        isMoving = false;
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

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MobileEnemy : Enemies
{
    [SerializeField] float speed;
    [SerializeField] float timeBetweenRotation;
    [SerializeField] protected int damage;
    private bool isMoving = true;
    private bool isInsideDome = false;
    protected GameObject touchingDome;
    private void Start()
    {
        base.Start();
        Invoke("ToRotate", timeBetweenRotation);
    }
    protected void Update()
    {
        base.Update();
        if (isMoving)
        {
            ToMove();
        }
        if(touchingDome == null)
        {
            GetComponent<Rigidbody>().isKinematic = false;
            isMoving = true;
        }
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

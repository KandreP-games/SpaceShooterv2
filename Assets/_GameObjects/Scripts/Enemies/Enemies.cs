using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemies : MonoBehaviour
{
    [SerializeField] int hp;
    [SerializeField] protected int damage;
    [SerializeField] GameObject prefabExplosion;
    [SerializeField] TextMesh hpText;
    [SerializeField] float delay;
    public static bool powerUpEffect = false;

    protected GameObject player;

    protected enum ESTADO { Normal, Siguiendo};
    protected ESTADO estado = ESTADO.Normal;


    protected void Start()
    {
        hpText.text = hp.ToString();
        player = GameObject.FindGameObjectWithTag("Player");
    }
    protected void Update()
    {
        if (powerUpEffect)
        {
            ToTakeDamage(50);
        }
    }
    private void LateUpdate()
    {
        powerUpEffect = false;
    }

    public void ToTakeDamage(int damageTaken)
    {
        hp -= damageTaken;
        hpText.text = hp.ToString();
        if (hp <= 0)
        {
            ToDie();
        }
    }
    protected void ToDie()
    {
        Instantiate(prefabExplosion, transform.position, transform.rotation);
        Invoke("ToDestroy", 0);
    }
    private void ToDestroy()
    {
        Destroy(gameObject);
    }

}

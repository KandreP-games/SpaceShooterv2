using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemies : MonoBehaviour
{
    [SerializeField] int hp;
    [SerializeField] int damage;
    [SerializeField] GameObject prefabExplosion;
    [SerializeField] TextMesh hpText;
    [SerializeField] float delay;
    public void Start()
    {
        hpText.text = hp.ToString();
    }

    public void toTakeDamage(int damageTaken)
    {
        hp -= damageTaken;
        hpText.text = hp.ToString();
        if (hp <= 0)
        {
            toDie();
        }
    }
    private void toAttack()
    {

    }
    private void toDie()
    {
        Instantiate(prefabExplosion, transform.position, transform.rotation);
        Invoke("toDestroy", 0);
    }
    private void toDestroy()
    {
        Destroy(gameObject);
    }

}

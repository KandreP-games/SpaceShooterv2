using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] int damage;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            collision.gameObject.GetComponent<Enemies>().toTakeDamage(damage);
        }
        else
        {
            Invoke("DestroyBullet", 2);
        }
        
    }
    private void DestroyBullet()
    {
        Destroy(gameObject);
    }
}

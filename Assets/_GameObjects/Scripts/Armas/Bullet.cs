using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    private static int damage = 20;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Enemy") || collision.gameObject.CompareTag("StaticEnemy"))
        {
            collision.gameObject.GetComponent<Enemies>().ToTakeDamage(damage);
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
    public static void ToPowerUp(int addedDamage)
    {
        damage += addedDamage;
    }
}

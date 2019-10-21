using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurretBullet : MonoBehaviour
{
    private int damage;
    private void OnCollisionEnter(Collision collision)
    {
        if(collision.collider.tag == "Player")
        {
            print("Damage player");
            collision.collider.GetComponent<Player1>().playerHp -= 10;
            Invoke("Destroy", 0);
        }
        else
        {
            print("Miss shot");
            Invoke("Destroy", 2);
        }
    }

    private void Destroy()
    {
        Destroy(gameObject);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AmmoBox : MonoBehaviour
{
    [SerializeField] int boxAmmoNum;
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.name == "Player")
        {
            print("More ammo for ya");
            //We recharge the ammo of the player
            //other.gameObject.GetComponent<Player1>().toRecharge(boxAmmoNum);
            //We destroy the box, so its not used again
            Destroy(gameObject);
        }
    }
}

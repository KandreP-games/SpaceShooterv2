using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player1 : MonoBehaviour
{
    [SerializeField] PistolGun gun;
    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            ToTrigger();
        }
    }
    void ToTrigger()
    {
        gun.ToShoot();
    }
    public void toRecharge(int boxAmmoNum)
    {
        gun.Recharge(boxAmmoNum);
    }
}

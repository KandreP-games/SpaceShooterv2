using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PistolGun : MonoBehaviour
{
    [SerializeField] GameObject bulletPrefab;
    [SerializeField] Transform bulletSpawn;
    [SerializeField] float bulletForce;
    [SerializeField] int maxBullets;
    [SerializeField] int bulletsLeft;
    [SerializeField] Text bulletsLeftText; 
    private void Start()
    {
        bulletsLeft = maxBullets;
    }
    private void Update()
    {
        bulletsLeftText.text = bulletsLeft.ToString();

    }
    public void Recharge(int boxAmmoNum)
    {
        bulletsLeft = Mathf.Min(bulletsLeft + boxAmmoNum, maxBullets);
    }
    public void ToShoot()
    {
        if (bulletsLeft > 0)
        {
            GameObject bullet = Instantiate(bulletPrefab);
            bullet.transform.position = bulletSpawn.position;
            bullet.transform.rotation = bulletSpawn.rotation;
            bullet.GetComponent<Rigidbody>().AddForce(bullet.transform.forward * bulletForce);
            bulletsLeft--;
        }
        else
        {
            print("No more bullets for ya");
        }
        
    }
}

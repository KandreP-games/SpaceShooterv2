using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootingSystem : MonoBehaviour
{
    private GameObject target;
    private float distanceToTarget;
    [SerializeField] float cadence;
    [SerializeField] float force;
    [SerializeField] Transform bulletSpawn;
    [SerializeField] GameObject bulletPrefab;
    void Start()
    {
        target = GameObject.Find("Player");
    }

    // Update is called once per frame
    void Update()
    {
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.name == "Player")
        {
            print("Turret trigger enter");
            InvokeRepeating("Shoot", 0, cadence);
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if(other.name == "Player")
        {
            CancelInvoke("Shoot");
        }
    }
    private void Shoot()
    {
        GameObject bullet = Instantiate(bulletPrefab, bulletSpawn.position, bulletSpawn.rotation);
        bullet.GetComponent<Rigidbody>().AddForce(bullet.transform.forward * force);
    }
}

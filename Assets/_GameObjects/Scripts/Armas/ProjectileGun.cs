using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileGun : Gun
{
    [SerializeField] GameObject projectilePrefab;
    [SerializeField] GameObject projectileSpawn;
    [SerializeField] float force;
    public override void Shoot()
    {
        GameObject projectile = Instantiate(projectilePrefab, projectileSpawn.transform.position, projectileSpawn.transform.rotation);
        projectile.GetComponent<Rigidbody>().AddForce(projectile.transform.forward * force);
    }
}


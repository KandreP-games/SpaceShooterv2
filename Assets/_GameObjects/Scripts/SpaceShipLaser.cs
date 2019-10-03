using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpaceShipLaser : MonoBehaviour
{
    [SerializeField] Transform laserTransform;
    [SerializeField] GameObject prefabLaser;
    [SerializeField] float laserForce;
    [SerializeField] AudioSource laserSound;
    private void Start()
    {
        InvokeRepeating("ToShoot", 5, Random.Range(0.1f, 3f));
    }
    private void ToShoot()
    {
        GameObject laser = Instantiate(prefabLaser, laserTransform);
        laser.transform.position = laserTransform.position;
        laser.transform.rotation = laserTransform.rotation;
        laser.GetComponent<Rigidbody>().AddForce(laser.transform.forward * laserForce);
        laserSound.Play();
    }
}

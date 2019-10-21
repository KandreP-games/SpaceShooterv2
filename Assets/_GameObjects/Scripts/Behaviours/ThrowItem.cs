using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThrowItem : MonoBehaviour
{
    [SerializeField] GameObject knifePrefab;
    [SerializeField] GameObject grenadePrefab;
    [SerializeField] Transform throwableSpawner;
    [SerializeField] float force;
    [SerializeField] float torque;
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.G))
        {
            GameObject grenade = Instantiate(grenadePrefab, throwableSpawner.position, throwableSpawner.rotation);
            grenade.GetComponent<Rigidbody>().AddForce(grenade.transform.forward * force);
        }   else if (Input.GetKeyDown(KeyCode.F))
        {
            GameObject knife = Instantiate(knifePrefab, throwableSpawner.position, throwableSpawner.rotation);
            knife.GetComponent<Rigidbody>().AddForce(knife.transform.forward * force);
        }    
    }
}

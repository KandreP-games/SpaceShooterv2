using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KnifeProjectile : MonoBehaviour
{
    private Rigidbody rb;
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        if(rb.velocity.magnitude > 0.05f)
        {
            transform.Rotate(1000 * Time.deltaTime, 0, 0, Space.Self);
        }
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.collider.name != "Player")
        {
            transform.parent = collision.transform;

            rb.isKinematic = true;
        }
        if(collision.collider.tag == "Enemy")
        {
            collision.collider.GetComponent<Enemies>().ToTakeDamage(10);
        }
    }
}

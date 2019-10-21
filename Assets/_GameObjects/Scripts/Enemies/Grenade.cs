using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grenade : MonoBehaviour
{

    [SerializeField] GameObject explosionPrefab;
    [SerializeField] float delayExplosion;
    [SerializeField] int damage;
    [SerializeField] int power;
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        delayExplosion -= Time.deltaTime;
        if(delayExplosion <= 0)
        {
            Instantiate(explosionPrefab,transform.position, transform.rotation);
            Destroy(gameObject);
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Enemy")
        {
            other.GetComponent<Enemies>().GrenadeDamage(delayExplosion, damage, power);
        }
    }
}

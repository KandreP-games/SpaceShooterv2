using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SniperShoot : Gun
{
    [SerializeField] Transform puntoDisparo;
    [SerializeField] GameObject prefabMarca;
    [SerializeField] Camera mainCamera;
    [SerializeField] int damage;

    void Update()
    {
             base.Update();
            if (Input.GetMouseButton(1))
            {
                //pongo el FOV en 20
                mainCamera.fieldOfView = 20;
            }
            else if (Input.GetMouseButtonUp(1))
            {
                //Pongo el FOV en 60
                mainCamera.fieldOfView = 60;
            }
        
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            Shoot();
        }
        Debug.DrawRay(puntoDisparo.position, puntoDisparo.forward * 100, Color.green);
    }

    public override void Shoot()
    {
        RaycastHit rch;
        /*
        bool hayImpacto = Physics.Raycast(
                puntoDisparo.position,
                puntoDisparo.forward,
            out rch);
        */
        Ray rayito = new Ray(puntoDisparo.position, puntoDisparo.forward);
        bool hayImpacto = Physics.Raycast(rayito, out rch);
        if (hayImpacto)
        {
            Debug.DrawRay(puntoDisparo.position, puntoDisparo.forward * rch.distance, Color.red, Mathf.Infinity);
            print(rch.collider.gameObject.name);
           if(rch.collider.gameObject.tag == "Enemy" || rch.collider.gameObject.tag == "StaticEnemy")
            {
                rch.collider.gameObject.GetComponent<Enemies>().ToTakeDamage(damage);
            }
            GameObject impacto = Instantiate(prefabMarca, rch.transform);
            impacto.transform.position = rch.point;
            impacto.transform.rotation = Quaternion.FromToRotation(Vector3.back, rch.normal);
            impacto.transform.Translate(Vector3.back * 0.01f);
            //Debug.DrawRay(rch.point, rch.normal, Color.blue, 10);
        }
    }
}

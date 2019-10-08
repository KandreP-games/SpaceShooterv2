using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sniper : Gun
{
    [SerializeField] Camera mainCamera;
    private void Update()
    {
       // base.Update();
        if (Input.GetMouseButton(1))
        {
            //pongo el FOV en 20
            mainCamera.fieldOfView = 20;
        }else if (Input.GetMouseButtonUp(1))
        {
            //Pongo el FOV en 60
            mainCamera.fieldOfView = 60;
        }
    }
    public override void Shoot()
    {

    }
}

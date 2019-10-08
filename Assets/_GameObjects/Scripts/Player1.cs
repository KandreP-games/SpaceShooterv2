using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player1 : MonoBehaviour
{
    [SerializeField] Gun[] guns;
    [SerializeField] int activeGun = 0;
    private bool keyDown;

    private void Update()
    {
        if (Input.GetMouseButton(0))
        {
            ToTrigger();
        }
        if (Input.GetKeyDown(KeyCode.R))
        {
            ToRecharge();
        }
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            ChangeGun(0);
        } else if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            ChangeGun(1);
        }
        else if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            ChangeGun(2);
        }
        else if (Input.GetKeyDown(KeyCode.Alpha4))
        {
            ChangeGun(3);
        }

    }
    public void ToRecharge()
    {
        guns[activeGun].ToRecharge();
    }
    void ToTrigger()
    { 
        guns[activeGun].TryShoot();
    }
    //Función cambiar de arma
    void ChangeGun(int gunNumber)
    {
        if (gunNumber != activeGun) //Si el arma elegida es distinta del arma activa se ejecuta el bloque if
        {
            activeGun = gunNumber;
            // El bucle for a continuación desactiva todas las armas activas
            for (int i = 0; i < guns.Length; i++)
            {
                guns[i].gameObject.SetActive(false);
            }
            //Activa el arma elegida
            guns[activeGun].gameObject.SetActive(true);
        }        
    }
}

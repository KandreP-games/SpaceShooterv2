using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player1 : MonoBehaviour
{
    [SerializeField] Gun[] guns;
    [SerializeField] int activeGun = 0;
    private bool keyDown;
    public int playerHp = 100;
    [SerializeField] Text hpText;

    private void Update()
    {
        hpText.text = playerHp.ToString();
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
        /*else if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            ChangeGun(2);
        }
        else if (Input.GetKeyDown(KeyCode.Alpha4))
        {
            ChangeGun(3);
        }*/
    }

    public void ToRecharge()
    {
        guns[activeGun].ToRecharge();
    }

    void ToTrigger()
    { 
        guns[activeGun].TryShoot();
    }
    public void TakeAmmo(int addedAmmo)
    {
        guns[activeGun].TakeAmmo(addedAmmo);
    }
    public void ChangeLife(int lifeChanged)
    {
        playerHp += lifeChanged;
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

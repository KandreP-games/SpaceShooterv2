using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
[RequireComponent(typeof(AudioSource))]
public abstract class Gun : MonoBehaviour
{   
    [Header("Time in between each shot(s)")]
    [Range(0f,10f)]
    [SerializeField] float cadence; //Tiempo entre disparo y disparo
    [Header("Time that is spent in recharging (s)")]
    [Range(1f, 4f)]
    [SerializeField] float rechargeTime;
    [Space(30)]
    [Header("Charger capacity")]
    [SerializeField] int chargerCapacity;
    [SerializeField] int chargersLeft;
    [SerializeField] int ammoLeft;
    [Header("Sounds")]
    [SerializeField] AudioClip acShoot;
    [SerializeField] AudioClip acRecharge;
    [SerializeField] AudioClip acFail;
    [SerializeField] Text ammoTxt;
    [SerializeField] Text chargerTxt;
    private AudioSource audioSource;
    public bool charging;
    public bool waitingCadence; //Time between each shot (cadence)
    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
        ammoLeft = chargerCapacity;
        audioSource.PlayOneShot(acRecharge);
        charging = false;
        waitingCadence = false;
    }
    private void Update()
    {
        chargerTxt.text = chargersLeft.ToString();
        ammoTxt.text = ammoLeft.ToString();
    }
    public void TryShoot()
    {
        bool canShoot = ammoLeft > 0 && charging == false && waitingCadence == false;
        if (canShoot)
        {
            Shoot();
            audioSource.PlayOneShot(acShoot);
            AfterShoot();
        }
    }
    public abstract void Shoot();
    public void ToRecharge()
    {
        if(chargersLeft > 0 && charging == false)
        {
            audioSource.PlayOneShot(acRecharge);
            ammoLeft = chargerCapacity;
            chargersLeft--;
            
            charging = true;
            Invoke("ChargingFinished", rechargeTime);
        }
    }
    public void PickUpAmmo(int pickedUpChargers)
    {

    }
    protected void AfterShoot()
    {
        ammoLeft--;
        
        waitingCadence = true;
        Invoke("CadenceFinished", cadence);
    }
    private void CadenceFinished()
    {
        waitingCadence = false;
    }
    private void ChargingFinished()
    {
        charging = false;
    }
}

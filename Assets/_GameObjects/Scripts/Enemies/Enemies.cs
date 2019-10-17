using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemies : MonoBehaviour
{
    [SerializeField] int hp;
    [SerializeField] GameObject prefabExplosion;
    [SerializeField] TextMesh hpText;
    [SerializeField] float delay;
    public static bool powerUpEffect = false;

    protected GameObject player;

    protected enum ESTADO { Normal, Siguiendo};
    protected ESTADO estado = ESTADO.Normal;


    protected void Start()
    {
        hpText.text = hp.ToString() + "/100";
        player = GameObject.FindGameObjectWithTag("Player");
    }
    protected void Update()
    {
        if (powerUpEffect)
        {
            ToTakeDamage(50);
        }
    }
    private void LateUpdate()
    {
        powerUpEffect = false;
    }

    public void ToTakeDamage(int damageTaken)
    {
        hp -= damageTaken;
        hpText.text = hp.ToString() + "/100";
        if (hp <= 0)
        {
            ToDie();
        }
    }
    protected void ToDie()
    {
        Instantiate(prefabExplosion, transform.position, transform.rotation);
        RandomSpawnPowerUp();
        Invoke("ToDestroy", 0);
    }
    private void ToDestroy()
    {
        Destroy(gameObject);
    }
    private void RandomSpawnPowerUp()
    {
        float random = Random.Range(0f, 1f);
        PowerUpSpawningManagement pu = GameObject.FindGameObjectWithTag("GameManager").GetComponent<PowerUpSpawningManagement>();
        if (random < 0.4f)
        {
            pu.ToSpawn(PowerUpSpawningManagement.PowerUpToSpawn.ammoBox, transform);
        } else if (0.4f < random && random < 0.7f)
        {
            pu.ToSpawn(PowerUpSpawningManagement.PowerUpToSpawn.healthBox, transform);
        } else if (0.7f < random && random<0.8f)
        {
            pu.ToSpawn(PowerUpSpawningManagement.PowerUpToSpawn.powerUp, transform);
        }
        
    }

}

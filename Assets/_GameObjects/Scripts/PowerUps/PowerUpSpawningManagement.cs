using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpSpawningManagement : MonoBehaviour
{
    [SerializeField] GameObject healthBoxPrefab;
    [SerializeField] GameObject powerUpPrefab;
    [SerializeField] GameObject enemyDamagePrefab;

    public enum PowerUpToSpawn {healthBox, powerUp, enemyDamage}

public void ToSpawn(PowerUpToSpawn powerUpToSpawn, Transform enemyKilledTransform)
    {
        switch(powerUpToSpawn)
        {
            case PowerUpToSpawn.healthBox:
                Instantiate(healthBoxPrefab, enemyKilledTransform.position, enemyKilledTransform.rotation);
                break;
            case PowerUpToSpawn.powerUp:
                Instantiate(powerUpPrefab, enemyKilledTransform.position, enemyKilledTransform.rotation);
                break;
            case PowerUpToSpawn.enemyDamage:
                Instantiate(enemyDamagePrefab, enemyKilledTransform.position, enemyKilledTransform.rotation);
                break;
        }
    }
}

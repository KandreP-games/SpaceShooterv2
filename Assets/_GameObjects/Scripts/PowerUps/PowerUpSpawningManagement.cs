using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpSpawningManagement : MonoBehaviour
{
    [SerializeField] GameObject healthBoxPrefab;
    [SerializeField] GameObject powerUpPrefab;
    [SerializeField] GameObject ammoBoxPrefab;

    public enum PowerUpToSpawn {healthBox, powerUp, ammoBox}

public void ToSpawn(PowerUpToSpawn powerUpToSpawn, Transform enemyKilledTransform)
    {
        switch(powerUpToSpawn)
        {
            case PowerUpToSpawn.healthBox:
                Instantiate(healthBoxPrefab, enemyKilledTransform.position + new Vector3(0,1,0) , Quaternion.Euler(45,45,45));
                break;
            case PowerUpToSpawn.powerUp:
                Instantiate(powerUpPrefab, enemyKilledTransform.position + new Vector3(0, 1, 0), Quaternion.Euler(45, 45, 45));
                break;
            case PowerUpToSpawn.ammoBox:
                Instantiate(ammoBoxPrefab, enemyKilledTransform.position + new Vector3(0, 1, 0), Quaternion.Euler(45, 45, 45));
                break;
        }
    }
}

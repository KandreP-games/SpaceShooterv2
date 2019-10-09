using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DummyEnemy : MobileEnemy
{
    private GameObject player;
    private float distance;

    private void ToFleeAway()
    {
       distance = Vector3.Distance(player.transform.position, transform.position);
        if (distance < 5)
        {

        }
    }
}

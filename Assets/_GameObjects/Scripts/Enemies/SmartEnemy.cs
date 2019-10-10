using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SmartEnemy : MobileEnemy
{
    private float distancePlayer;
    [SerializeField] float followDistance;
    void Update()
    {
        base.Update();
        distancePlayer = Vector3.Distance(transform.position, player.transform.position);
        if(distancePlayer <= followDistance)
        {
            estado = ESTADO.Siguiendo;
            Vector3 Target = new Vector3(player.transform.position.x, transform.position.y, player.transform.position.z);
            transform.LookAt(Target);
        }
        else
        {
            estado = ESTADO.Normal;
        }
    }
}

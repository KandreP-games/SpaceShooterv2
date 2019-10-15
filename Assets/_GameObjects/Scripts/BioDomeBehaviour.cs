using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BioDomeBehaviour : MonoBehaviour
{
    private void Start()
    {
        
    }
    private void Update()
    {
        if (GameManager.isInside)
        {
            Physics.gravity = new Vector3(0, -9.8f, 0);
        }else if(GameManager.isInside == false)
        {
            Physics.gravity = new Vector3(0, -4.4f, 0);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.name == "Player")
        {
            GameManager.isInside = !GameManager.isInside;
        }
    }


}

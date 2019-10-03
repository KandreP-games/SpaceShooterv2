using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InsideBehaviour : MonoBehaviour
{
    private bool inside = false;
    [SerializeField] GameObject player;
    [SerializeField] AudioClip birds;
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == "Player")
        {
            inside = !inside;
        }
    }
    private void Update()
    {
        if (inside == true)
        {
           // GetComponent<AudioSource>.
        }
    }
}

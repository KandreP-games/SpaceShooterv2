using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Teleport : MonoBehaviour
{
    [SerializeField] string nombreEscena;
    [SerializeField] float delay;
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.name == "Player")
        {
            Invoke("sceneChange", delay);
        }
    }
    private void sceneChange()
    {
        //Cambio de escena
        SceneManager.LoadScene(nombreEscena);
        
    }
}

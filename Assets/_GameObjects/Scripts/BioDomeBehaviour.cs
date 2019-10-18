using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BioDomeBehaviour : MonoBehaviour
{
    public int bioDomeHp = 100;
    private bool enemyInside = false;
    private Collider other;
    public int enemiesInside = 0;
    [SerializeField] TextMesh bioDomeHpText;

    private void Start()
    {
        InvokeRepeating("ToTakeDamage", 0, 1);
    }

    private void Update()
    {
        if (GameManager.isInside)
        {
            Physics.gravity = new Vector3(0, -9.8f, 0);
        }
        else if (GameManager.isInside == false)
        {
            Physics.gravity = new Vector3(0, -4.4f, 0);
        }
        bioDomeHpText.text = bioDomeHp.ToString() + "/100";

        if (bioDomeHp <= 0)
        {
            gameObject.active = false; 
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.name == "Player")
        {
            GameManager.isInside = !GameManager.isInside;
        }
        else if (other.tag == "Enemy")
        {
            enemiesInside += 1;
            other.GetComponent<MobileEnemy>().ToStop();
            other.GetComponent<MobileEnemy>().ChangeDomeStatus();
            other.GetComponent<MobileEnemy>().ReferenceDome(gameObject);
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.name == "Player")
        {
            GameManager.isInside = !GameManager.isInside;
        }
    }
    public void OneLessEnemy()
    {
        enemiesInside -= 1;
    }
    private void ToTakeDamage()
    {
        bioDomeHp -= enemiesInside;
    }
}

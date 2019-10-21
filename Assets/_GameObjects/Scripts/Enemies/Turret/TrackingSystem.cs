using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrackingSystem : MonoBehaviour
{
    [SerializeField] float speed;
    public GameObject target;
    Vector3 lastKnownPosition = Vector3.zero;
    Quaternion lookAtRotation;
    private void Start()
    {
        target = GameObject.Find("Player");
    }
    private void Update()
    {
        if (target)
        {
            if (lastKnownPosition != target.transform.position)
            {
                lastKnownPosition = target.transform.position;
                lookAtRotation = Quaternion.LookRotation(lastKnownPosition - transform.position);
            }

            transform.rotation = Quaternion.RotateTowards(transform.rotation, lookAtRotation, speed * Time.deltaTime);
        }

    }
}

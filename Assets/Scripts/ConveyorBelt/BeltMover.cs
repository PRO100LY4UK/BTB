using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeltMover : MonoBehaviour
{
    [SerializeField]
    private Transform endPoint;
    [SerializeField]
    private float speed;
    
    private void OnTriggerStay(Collider other)
    {
        if (other.tag == "TrashBox")
        {
            other.transform.position = Vector3.MoveTowards(other.transform.position, endPoint.position, speed * Time.deltaTime);
        }
    }
}

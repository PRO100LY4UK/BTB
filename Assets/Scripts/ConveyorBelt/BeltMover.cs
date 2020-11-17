using UnityEngine;

public class BeltMover : MonoBehaviour
{
    [SerializeField]
    private Transform endPoint = default;
    [SerializeField]
    private float speed = default;
    
   

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.GetComponent<Interactable>())
        {
            other.transform.position = Vector3.MoveTowards(other.transform.position, endPoint.position, speed * Time.deltaTime);
        }
    }
}

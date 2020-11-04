using UnityEngine;
using UnityEngine.UI;

public class collectable : MonoBehaviour
{
    [SerializeField]
    private Button pickUpButton;
    [SerializeField]
    private Button dropButton;
    [SerializeField]
    private GameObject objectToPickUp;
    [SerializeField]
    private GameObject pickPositiion;
    [SerializeField]
    private GameObject onCarry;
    void Start()
    {
        
    }

    
    void Update()
    {
        if (onCarry != null)
        {
            dropButton.gameObject.SetActive(true);
        }
        else
        {
            dropButton.gameObject.SetActive(false);
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "TrashBox")
        {
            print("Enter"); 
            if (onCarry == null)
            {
                pickUpButton.gameObject.SetActive(true);
                objectToPickUp = other.gameObject;
            }
            
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "TrashBox")
        {
            print("Exit");
            pickUpButton.gameObject.SetActive(false);
            objectToPickUp = null;
        }
    }

    public void PickUp()
    {
        onCarry = objectToPickUp;
        objectToPickUp.transform.parent = pickPositiion.transform;
        objectToPickUp.transform.position = pickPositiion.transform.position;
        objectToPickUp.GetComponent<Rigidbody>().isKinematic = true;
       
    }

    public void Drop()
    {
        onCarry.GetComponent<Rigidbody>().isKinematic = false;
        onCarry.transform.parent = null;
        onCarry = null;
    }


}

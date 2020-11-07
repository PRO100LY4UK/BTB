using System;
using UnityEngine;

[RequireComponent(typeof(Casting))]
public class Interaction : MonoBehaviour
{
    [Header("Developer Buttons setup")]
    public KeyCode interactKey;
    public KeyCode abortKey;

    [Header("Player Body Setup")] 
    [SerializeField] private GameObject pickPosition;
    public GameObject PickPosition => pickPosition;

    private Interactable target;
    private Interactable interactingTarget;
    
    private void Update()
    {
        InteractRoutine();
    }

    /*
     * Function to check if we are Interacting
     * if NOT => Check if we can Interact
     * if YES => Check if we can STOP Interact
     */
    private void InteractRoutine()
    {
        if (interactingTarget == null)
        {
            GetInteractableTarget();
        }
        else
        {
            if (Input.GetKeyDown(abortKey))
            {
                target.StopInteraction();
                interactingTarget = null;
            }
        }
    }

    /*
     * Check IF Interactable is INFRONT of us
     */
    private void GetInteractableTarget()
    {
        //SET TARGET to Casting.target IF it have INTERACTABLE Component, if not target = null
        // target = casting.target если casting.target существует и есть компонент 
        target = Casting.target != null ? Casting.target?.GetComponent<Interactable>() : null;
        
        if (target != null)
        {
            // () => FUNCTIONNAME , this is how you call a "delegate" EVENT , its also called a "callback function"
            InteractWithTarget(() => target.StartInteraction(gameObject));
        }
    }

    private void InteractWithTarget(Action interaction)
    {
        if (Input.GetKeyDown(interactKey))
        {
            interactingTarget = target;
            interaction.Invoke();
        }
    }

    /*[SerializeField]
    private Button pickUpButton;
    [SerializeField]
    private Button dropButton;
    [SerializeField]
    private GameObject objectToPickUp;
    [SerializeField]
    private GameObject pickPositiion;
    [SerializeField]
    private GameObject onCarry;

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
    }*/
}
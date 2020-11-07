using System.Collections;
using UnityEngine;

public class Wheel : Interactable
{
    private void Start()
    {
        OnInteractAction += StartInteracting;  // add StartInteracting to OnInteract void
        OnStopInteractAction += StopInteracting;
    }



    private void StartInteracting(GameObject entity)  
    {
        SetInteractingWith(entity);
        if (entity.CompareTag("Player"))
        {
            StartCoroutine(PlayerInteraction());
        }
        else
        {
            Debug.Log("Anything else is trying to access the Entity, not the Player");
        }
    }

    private IEnumerator PlayerInteraction()
    {
        Interaction playerInteraction = InteractingWith.GetComponent<Interaction>();
        gameObject.transform.parent = playerInteraction.PickPosition.transform;
        gameObject.transform.position = playerInteraction.PickPosition.transform.position;

        yield return new WaitForSeconds(1f);
    }

    private void StopInteracting()
    {
        if (InteractingWith.CompareTag("Player"))
        {
            StartCoroutine(StopPlayerInteraction());
        }
        else
        {
            Debug.Log("Stop interacting with something else");
        }
    }

    private IEnumerator StopPlayerInteraction()
    {
        Debug.Log("Stop Interacting with Player");
        StopCoroutine(PlayerInteraction());
        transform.parent = null;
        yield return null;
    }

}
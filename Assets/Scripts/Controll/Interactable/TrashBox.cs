using System.Collections;
using UnityEngine;

public class TrashBox : Interactable
{
    private void Start()
    {
        OnInteractAction += StartInteracting;
        OnStopInteractAction += StopInteracting;
    }

    /*
     * FIRST Function to CALL when we START INTERACTING with ENTITY(Can be PLAYER or ANOTHER GameObject)
     */
    private void StartInteracting(GameObject entity)
    {
        SetInteractingWith(entity);
        if (entity.CompareTag("Player"))
        {
            //Whenever Player is interacting with this object, we call the Coroutine,
            //why coroutine? Becouse its flexible in case we want to use animations or timers or anything else
            StartCoroutine(PlayerInteraction());
        }
        else
        {
            Debug.Log(("Anything else is trying to access the Entity but the Player"));
            //Something else then the player is trying to interact with
            //Do whatever
        }
    }

    /*
     * Function which gets called when Player is Interacting with THIS GAMEOBJECT(Interactable)
     */
    private IEnumerator PlayerInteraction()
    {
        Interaction playerInteraction = InteractingWith.GetComponent<Interaction>();
        //Pickup Item or whatever
        gameObject.transform.parent = playerInteraction.PickPosition.transform;
        gameObject.transform.position = playerInteraction.PickPosition.transform.position;
        
        yield return new WaitForSeconds(1f);
    }

    /*
     * Function which gets called when we want to STOP Interacting 
     */
    private void StopInteracting()
    {
        if (InteractingWith.CompareTag("Player"))
        {
            //Stop Interacting with Player
            StartCoroutine(StopPlayerInteraction());
        }
        else
        {
            Debug.Log("Stop interacting with something else");
            //Stop Interacting with something else
        }
    }

    /*
     * Function which gets called when we want to STOP INTERACTING WITH PLAYER
     */
    private IEnumerator StopPlayerInteraction()
    {
        //Drop Item or whatever
        Debug.Log(("Stop Interacting with Player"));
        StopCoroutine(PlayerInteraction());
        transform.parent = null;
        yield return null;
    }
}

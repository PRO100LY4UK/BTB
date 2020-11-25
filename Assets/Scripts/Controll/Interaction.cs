using System;
using UnityEngine;

[RequireComponent(typeof(Casting))]
public class Interaction : MonoBehaviour, IAction
{
    [Header("Developer Buttons setup")]
    
    public KeyCode interactKey;
    public KeyCode abortKey;

    [Header("Player Body Setup")] 
    [SerializeField] private GameObject pickPosition;
    public GameObject PickPosition => pickPosition;

    [Header("Interactable INFRONT of Player")]
    [SerializeField] private Interactable seeingTarget;
    [Header("Interacting WITH Target")]
    [SerializeField] private Interactable interactingTarget;

    private ActionScheduler actionScheduler;

    private void Awake()
        => actionScheduler = GetComponent<ActionScheduler>();

    private void Update()
        => InteractRoutine();
    

    /*
     * Function to check if we are Interacting
     * if NOT => Check if we can Interact
     * if YES => Check if we can STOP Interact
     */
    private void InteractRoutine()
    {
        if (!interactingTarget)
        {
            GetInteractableTarget();
        }
        else if (interactingTarget)
        {
            if (Input.GetKeyDown(abortKey))
            {
                seeingTarget.StopInteraction();
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
        seeingTarget = Casting.target != null ? Casting.target?.GetComponent<Interactable>() : null;

        if (!seeingTarget) return; 
        // () => FUNCTIONNAME , this is how you call a "delegate" EVENT , its also called a "callback function"
        InteractWithTarget();
    }

    private void InteractWithTarget()
    {
        if (Input.GetKeyDown(interactKey))
        {
            StartInteraction();
        }
        UIHandler.Instance.InteractionUiHandler.PrepareInteraction(true);
    }

    public void StartInteraction()
    {
        if (!seeingTarget) return;
        actionScheduler.StartAction(this);
        interactingTarget = seeingTarget;
        seeingTarget.StartInteraction(gameObject);
        
    }

    public void Cancel()
    {
        interactingTarget.StopInteraction();
        interactingTarget = null;
    }
}
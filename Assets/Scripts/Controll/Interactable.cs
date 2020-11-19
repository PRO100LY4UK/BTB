using UnityEngine;

public abstract class Interactable : MonoBehaviour
{
    //EVENT which is EMPTY at the Start
    public delegate void StopInteractAction();

    public StopInteractAction OnStopInteractAction;
    
    //EVENT which is EMPTY at the Start
    public delegate void InteractAction(GameObject entity);

    public InteractAction OnInteractAction;
 
    [SerializeField] private GameObject interactingWith;
    public GameObject InteractingWith => interactingWith;    //interactingWith take value form InteractingWith

    public void StopInteraction()
    {
        if (OnStopInteractAction != null) OnStopInteractAction();
    }

    public void StartInteraction(GameObject entity)
    {
        if (OnInteractAction != null) OnInteractAction(entity);

        OnInteractAction?.Invoke(entity);
    }

    public void SetInteractingWith(GameObject newTarget)
        => interactingWith = newTarget;
    
}
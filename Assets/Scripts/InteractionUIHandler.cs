using UnityEngine.UI;
using UnityEngine;
using UnityEngine.Events;

public class InteractionUIHandler : MonoBehaviour
{
    [SerializeField] private Button interactBtn;
    [SerializeField] private Button cancelInteractBtn;
    public Button CancelInteractBtn => cancelInteractBtn;
    
    public UnityEvent OnInteract;
    public UnityEvent OnCancelInteraction;
    
    private void Start()
    {
        OnInteract.AddListener(() => PrepareInteraction(false));
        OnInteract.AddListener(() => PrepareCancelInteraction(true));
        OnCancelInteraction.AddListener(() => PrepareCancelInteraction(false));
        
        interactBtn.onClick.AddListener(OnInteract.Invoke);
        cancelInteractBtn.onClick.AddListener(OnCancelInteraction.Invoke);
    }

    public void PrepareInteraction(bool state)
    {
        interactBtn.gameObject.SetActive(state);
    }

    public void PrepareCancelInteraction(bool state)
    {
        cancelInteractBtn.gameObject.SetActive(state);
    }
}

using UnityEngine;

public class UIHandler : MonoBehaviour
{
    [SerializeField] private DataScreen dataScreen = default;
    
    [SerializeField] private InteractionUIHandler interactionUiHandler = default;
    public InteractionUIHandler InteractionUiHandler => interactionUiHandler;
    
    
    public static UIHandler Instance;

    private void Awake()
    {
        if (Instance != this || Instance == null)
        {
            Instance = this;
        }
    }

    private void ToggleScreen()
        => dataScreen.ToggleScreen();
    
}
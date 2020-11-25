using UnityEngine;
using UnityEngine.UI;

public class UIHandler : MonoBehaviour
{
    

    [SerializeField] private DataScreen dataScreen;
    [SerializeField] private Button interactButton;
    [SerializeField] private Button endInteractButton;

    public static UIHandler Instance;

    private void Awake()
    {
        Instance = this;
    }


    private void ToggleScreen()
        => dataScreen.ToggleScreen();
    
}
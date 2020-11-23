using UnityEngine;

public class UIHandler : MonoBehaviour
{
    [SerializeField] private DataScreen dataScreen;

    public static UIHandler Instance;

    //private void Start()
      //  => EventHandler.Instance.onTestEvent += ToggleScreen;


    private void ToggleScreen()
        => dataScreen.ToggleScreen();
    
}
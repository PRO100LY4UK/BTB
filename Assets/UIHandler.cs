using UnityEngine;

public class UIHandler : MonoBehaviour
{
    [SerializeField] private GameObject interactBtn;
    [SerializeField] private GameObject cancelBtn;
    
    public static UIHandler Instance;

    private void Awake()
    {
        if (Instance == null || Instance != this)
        {
            Instance = this;
        }
    }
    
    public void ToggleInteractBtn()
        => interactBtn.SetActive(!interactBtn.activeSelf);

    public void ToggleCancelBtn()
        => cancelBtn.SetActive(!cancelBtn.activeSelf);
}
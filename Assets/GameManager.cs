using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager gameManager;
    private void Awake() => gameManager = this;
    
    public string TruckStatus;

    
}

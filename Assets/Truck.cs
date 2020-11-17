using UnityEngine;

public class Truck : MonoBehaviour
{
    private void Start()
        => EventHandler.Instance.onTruckDestroy += DestroyTruck;

    private void DestroyTruck()
        => Destroy(gameObject);
    
}
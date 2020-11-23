using UnityEngine;

public class TruckSpawner : MonoBehaviour
{
    [Header("Vehicle List")]
    public GameObject[] Vehicles;

    [Header("Truck Spawn Point")]
    [SerializeField] private GameObject vehicleSpawnPoint = default;
    
    
    private void Start()
    {
        EventHandler.Instance.onTruckSpawn += InstantiateRandomTruck;
        InstantiateRandomTruck();
    }

    
    private void InstantiateRandomTruck() => Instantiate(Vehicles[Random.Range(0, Vehicles.Length - 1)], vehicleSpawnPoint.transform.position, transform.rotation);
    
}
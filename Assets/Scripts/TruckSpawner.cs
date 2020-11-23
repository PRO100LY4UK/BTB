using UnityEngine;
using System.Collections.Generic;

public class TruckSpawner : MonoBehaviour
{
    [Header("Vehicle List")]
    public GameObject[] vehicles = default;
    
    [Header("TruckWayPoints")] 
    [SerializeField] private List<GameObject> destinationPoints = default;
    public List<GameObject> DestinationPoints => destinationPoints;
    
    
    private List<Truck> activeTrucks;
    public delegate Truck OnTruckSpawn();
    public OnTruckSpawn TruckSpawn;

    private void Start()
    {
        //Subscribe to event
        TruckSpawn += InstantiateRandomTruck;
        onTruckSpawn();
    }

    private Truck onTruckSpawn()
        => TruckSpawn?.Invoke();
    
    
    private Truck InstantiateRandomTruck()
        => Instantiate(vehicles[Random.Range(0, vehicles.Length - 1)], gameObject.transform.position, transform.rotation).GetComponent<Truck>();
    

    
}
using UnityEngine;
using System.Collections.Generic;

public class TruckSpawner : MonoBehaviour
{
    [Header("Vehicle List")]
    public GameObject[] vehicles = default;
    
    [Header("TruckWayPoints")] 
    [SerializeField] private List<Transform> comeDestinationPoints = default;
    [SerializeField] private List<Transform> leavDestinationPoints = default;
    public List<Transform> ComeDestinationPoints => comeDestinationPoints;
    public List<Transform> LeavDestinationPoints => leavDestinationPoints;


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
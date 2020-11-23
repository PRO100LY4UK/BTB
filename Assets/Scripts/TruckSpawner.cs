using System.Collections.Generic;
using UnityEngine;

public class TruckSpawner : MonoBehaviour
{
    [Header("Vehicle List")]
    public List<Truck> trucks;

    [Header("Truck Spawn Point")]
    [SerializeField] private GameObject vehicleSpawnPoint = default;
    [Header("Truck Destination Point")]
    [SerializeField] private GameObject vehicleDestination = default;

    private Truck drinvingTruck = default;

    /*
     * TODO:
     * Add new Event whenever a new Truck is Instantiated
     * Add new Event whenever a Truck is finisht
     */
    
    private void Start()
    {
        //Subscribe to event
    }

    private void SendNewTruck()
    {
        //Check if Truck is running
        if (drinvingTruck) return;
        
        //Make Truck drive to Destination Point
        
    }

    private void InstantiateRandomTruck()
    {
        //Create Function to get 1 random Truck from "trucks" List
        
    }
}
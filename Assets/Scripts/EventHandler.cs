using System;
using UnityEngine;

public class EventHandler : MonoBehaviour
{
    //Create Singleton to access the Class in other scripts
    public static EventHandler Instance;

    //Set Singleton to THIS GameObject
    private void Awake() 
        =>Instance = this;


    //Event whenever a NEW TRUCK is deployed
    public event Action onTruckSpawn;
    public void TruckSpawn() => onTruckSpawn?.Invoke();


    public event Action onTruckComing;
    public void TruckComing() => onTruckComing?.Invoke();


    //Create EMPTY Event (a list for example)
    public event Action onSpawnTrash;
    //Create Function to call the event
    public void SpawnTrash() => onSpawnTrash?.Invoke(); //if onTestEvent !=null => invoke


    public event Action onTruckLeaving;
    public void TruckLeaving() => onTruckLeaving?.Invoke();
        
    
    //Event whenever Truck is finisht
    public event Action onTruckDestroy;
    public void TruckDestroy() => onTruckDestroy?.Invoke();



 
}
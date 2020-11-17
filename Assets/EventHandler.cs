using System;
using UnityEngine;

public class EventHandler : MonoBehaviour
{
    //Create Singleton to access the Class in other scripts
    public static EventHandler Instance;

    //Set Singleton to THIS GameObject
    private void Awake() 
        =>Instance = this;

    private void Start()
    {
        TestEvent();
    }

    //Create EMPTY Event (a list for example)
    public event Action onTestEvent;
    //Create Function to call the event
    public void TestEvent()
    {
        //Is the EVENT empty? = No Functions in the event? Then do nothing
        if(onTestEvent != null) 
            //If there are functons in the event(in the list for example), we can call ALL FUNCTIONS
            onTestEvent.Invoke();
    }
    
    /*
     * TODO
     * Change onTestEvent and TestEvent Function name
     * Adjust Animation to take longer
     * Create a new Event by yourself
     */

    //Event whenever Truck is finisht
    public event Action onTruckDestroy;
    public void TruckDestroy()
    {
        if(onTruckDestroy != null) 
            onTruckDestroy.Invoke();
    }

    //Event whenever a NEW TRUCK is deployed
    public event Action onTruckDeploy;
    public void TruckDeploy()
    {
        if(onTruckDeploy != null) 
            onTruckDeploy.Invoke();
    }
}
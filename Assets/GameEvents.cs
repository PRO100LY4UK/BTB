using System;
using UnityEngine;

public class GameEvents : MonoBehaviour
{
    public static GameEvents gameEvents;

    private void Awake()
    {
        gameEvents = this;
    }

    public event Action<int> onDoorwayTriggerEnter;
    public void DoorwayTriggerEnter(int id)
    {
        onDoorwayTriggerEnter?.Invoke(id);
        /*if (onDoorwayTriggerEnter != null)
        {
            onDoorwayTriggerEnter();
        }
        */
    }

    public event Action<int> onDoorwayTriggerExit;
    public void DoorwayTriggerExit(int id) => onDoorwayTriggerExit?.Invoke(id);
    
        
    
}

 

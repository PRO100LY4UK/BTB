using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorController : MonoBehaviour
{
    public int id;
    private Vector3 startVector3;
    private Vector3 openVector3;
    void Start()
    {
        startVector3 = this.transform.position;
        openVector3.x = startVector3.x;
        openVector3.y = startVector3.y;
        openVector3.y += 13.2f;
        openVector3.z = startVector3.z;
        GameEvents.gameEvents.onDoorwayTriggerEnter += OnDoorwayOpen;
        GameEvents.gameEvents.onDoorwayTriggerExit += OnDoorwayClose;
        
    }

    private void OnDoorwayOpen(int id)
    {
        if (id == this.id)
        {
            this.transform.position = openVector3;

        }
    }
    
    private void OnDoorwayClose(int id)
    {
        if (id == this.id)
        {
            this.transform.position = startVector3;

        }
    }


    private void OnDestroy()
    {
        GameEvents.gameEvents.onDoorwayTriggerEnter -= OnDoorwayOpen;
        GameEvents.gameEvents.onDoorwayTriggerExit -= OnDoorwayClose;
    }
}

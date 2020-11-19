using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerArea : MonoBehaviour
{
    public int id;
    private void OnTriggerEnter(Collider other)
    {
        GameEvents.gameEvents.DoorwayTriggerEnter(id);
        Debug.Log("triggerEnter");
    }

    private void OnTriggerExit(Collider other)
    {
        GameEvents.gameEvents.DoorwayTriggerExit(id);
        Debug.Log("triggerExit");
    }
}

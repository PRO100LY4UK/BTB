using System;
using UnityEngine;

public class EventHandler : MonoBehaviour
{
    //Create Singleton to access the Class in other scripts
    public static EventHandler Instance;

    //Set Singleton to THIS GameObject
    private void Awake() 
        =>Instance = this;
}
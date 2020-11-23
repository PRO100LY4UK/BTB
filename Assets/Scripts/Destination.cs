using UnityEngine;
using System.Collections.Generic;

[CreateAssetMenu(fileName = "DestinationPoints", menuName = "Truck/Destination")]
public class Destination : ScriptableObject
{
    [SerializeField] private List<GameObject> destinationPoints;
}

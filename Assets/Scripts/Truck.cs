using UnityEngine;
using System.Collections.Generic;
using System.Collections;
using UnityEngine.AI;
using UnityEngine.Events;

public class Truck : MonoBehaviour
{
    [Header("TrashSpawnSettings")]
    [SerializeField]private GameObject spawnPoint;
    [SerializeField]private GameObject trashBox = default;
    [SerializeField]private int trashToSpawn;
    [SerializeField]private int spawnDelay = 2;

    public UnityEvent onTruckComing;
    public UnityEvent onSpawnTrash;
    public UnityEvent onTruckLeaving;
    public UnityEvent onTruckDestroy;
    
    private NavMeshAgent agent;
    private TruckSpawner truckSpawner;

    private List<GameObject> truckDestinationPoints;
    private int destination;

    private void Awake()
    {
        agent = GetComponent<NavMeshAgent>();
        truckSpawner = FindObjectOfType<TruckSpawner>();
        truckDestinationPoints = truckSpawner.DestinationPoints;
    }

    private void Start()
    {
        SubscribeToEvents();
        StartCoroutine(truckComing());
    }

    private IEnumerator truckComing()
    {
        onTruckComing.Invoke();
        foreach (var destinationPoint in truckDestinationPoints)
        {
            MoveTo(destinationPoint);
            yield return new WaitUntil(() => agent.hasPath);
            yield return new WaitUntil(() => agent.remainingDistance <= 0.5f);
        }
        yield return new WaitForSeconds(0.5f);
        onSpawnTrash.Invoke();
    }

    private void truckSpawningTrash()
    {
        StartCoroutine(Spawner());
    }

    private IEnumerator Spawner()
    {
        for (int i = 0; i < trashToSpawn; i++)
        {
            Instantiate(trashBox, spawnPoint.transform.position, Quaternion.identity);
            yield return new WaitForSeconds(spawnDelay);
        }
        onTruckLeaving.Invoke();
    }

    private void truckLeaving()
    {
        onTruckDestroy.Invoke();
    }

    private void DestroyTruck()
    {
        Destroy(gameObject);
        truckSpawner.TruckSpawn();
    }

    private void MoveTo(GameObject destination)
        => agent.SetDestination(destination.transform.position);

    private void SubscribeToEvents()
    {
        onSpawnTrash.AddListener(truckSpawningTrash);
        onTruckLeaving.AddListener(truckLeaving);
        onTruckDestroy.AddListener(DestroyTruck);
    }
}
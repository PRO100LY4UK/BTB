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

    private List<Transform> comeTruckDestinationPoints;
    private List<Transform> leavTruckDestinationPoints;
    private int destination;

    private void Awake()
    {
        agent = GetComponent<NavMeshAgent>();
        truckSpawner = FindObjectOfType<TruckSpawner>();
        comeTruckDestinationPoints = truckSpawner.ComeDestinationPoints;
        leavTruckDestinationPoints = truckSpawner.LeavDestinationPoints;
        
    }

    private void Start()
    {
        SubscribeToEvents();
        StartCoroutine(truckComing());
    }

    private IEnumerator truckComing()
    {
        onTruckComing.Invoke();
        foreach (var destinationPoint in comeTruckDestinationPoints)
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

    private void TruckLeave()
        => StartCoroutine(OnTruckLeave());
    
    
    private IEnumerator OnTruckLeave()
    {
        foreach (var destinationPoint in leavTruckDestinationPoints)
        {
            MoveTo(destinationPoint);
            yield return new WaitUntil(() => agent.hasPath);
            yield return new WaitUntil(() => agent.remainingDistance <= 0.5f);
        }
        yield return new WaitForSeconds(0.5f);
        onTruckDestroy.Invoke();
    }

    private void DestroyTruck()
    {
        Destroy(gameObject);
        truckSpawner.TruckSpawn();
    }

    private void MoveTo(Transform destination)
        => agent.SetDestination(destination.position);

    private void SubscribeToEvents()
    {
        onSpawnTrash.AddListener(truckSpawningTrash);
        onTruckLeaving.AddListener(TruckLeave);
        onTruckDestroy.AddListener(DestroyTruck);
    }
}
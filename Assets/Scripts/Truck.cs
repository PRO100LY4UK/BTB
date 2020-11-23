using UnityEngine;
using System.Collections;

public class Truck : MonoBehaviour
{    
    [Header("TrackStatus")]
    [SerializeField]private string truckStatus;

    [Header("TrashSpawnSettings")]
    [SerializeField]private GameObject spawnPoint;
    [SerializeField]private GameObject trashBox = default;
    [SerializeField]private int trashToSpawn;
    [SerializeField]private int spawnDelay = 2;

    [Header("TruckAnimations")]
    [SerializeField]private Animation truckAnim;    
    

    private void Start()
    {               
        EventHandler.Instance.onTruckComing += truckComing;
        EventHandler.Instance.onSpawnTrash += truckSpawningTrash;
        EventHandler.Instance.onTruckLeaving += truckLeaving;
        EventHandler.Instance.onTruckDestroy += DestroyTruck;

        EventHandler.Instance.TruckComing();
    }


    private void truckComing()
    {
        truckStatus = ("Coming");
        GameManager.gameManager.TruckStatus = truckStatus;
        truckAnim.Play("truckComing");
        
    }

    private void truckSpawningTrash()
    {
        truckStatus = ("SpawningTrash");
        GameManager.gameManager.TruckStatus = truckStatus;
        StartCoroutine(Spawner());
    }

    private IEnumerator Spawner()
    {
        for (int i = 0; i < trashToSpawn; i++)
        {
            Instantiate(trashBox, spawnPoint.transform.position, Quaternion.identity);
            yield return new WaitForSeconds(spawnDelay);
        }
        EventHandler.Instance.TruckLeaving();
    }


    private void truckLeaving()
    {
        truckStatus = ("Leaving");
        GameManager.gameManager.TruckStatus = truckStatus;
        truckAnim.Play("truckLeaving");
    }


    private void DestroyTruck()
    {
        Destroy(gameObject);
        GameManager.gameManager.TruckStatus = ("Destroyed");
        EventHandler.Instance.TruckSpawn();
    }
    

   
}
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrashSpawner : MonoBehaviour
{
    [SerializeField]
    private GameObject spawnPoint;
    [SerializeField]
    private GameObject trashBox;
    [SerializeField]
    private int trashToSpawn;
    [SerializeField]
    private int spawnDelay = 2;
    
    void Start()
    {
        
        
    }

    void TruckIsReady()
    {
        StartCoroutine(Spawner());
        
    }
    IEnumerator Spawner()
    {
        for (int i = 0; i < trashToSpawn; i++)
        {
            
            Instantiate(trashBox, spawnPoint.transform.position, Quaternion.identity);
            yield return new WaitForSeconds(spawnDelay);
            
            
        }
    }
}

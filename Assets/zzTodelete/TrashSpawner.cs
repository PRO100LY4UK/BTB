using System.Collections;
using UnityEngine;

public class TrashSpawner : MonoBehaviour
{
    [SerializeField]
    private GameObject spawnPoint;
    [SerializeField]
    private GameObject trashBox = default;
    [SerializeField]
    private int trashToSpawn;
    [SerializeField]
    private int spawnDelay = 2;
    
    private void TruckIsReady()
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
    }
}

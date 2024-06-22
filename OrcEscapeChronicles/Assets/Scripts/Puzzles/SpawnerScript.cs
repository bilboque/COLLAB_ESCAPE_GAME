using UnityEngine;
using Unity.Netcode;

public class ServerObjectSpawner : MonoBehaviour
{
    public GameObject objectPrefab; 
    public Transform spawnPosition;

    void Start()
    {
        if (NetworkManager.Singleton.IsServer)
        {
            SpawnObject();
        }
    }

    void SpawnObject()
    {
        // Instantiate the prefab
        GameObject newObject = Instantiate(objectPrefab, spawnPosition);

        // Get the NetworkObject component and spawn it
        NetworkObject networkObject = newObject.GetComponent<NetworkObject>();
        networkObject.Spawn();
    }
}

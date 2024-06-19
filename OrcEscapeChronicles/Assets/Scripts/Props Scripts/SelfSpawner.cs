using UnityEngine;
using Unity.Netcode;

public class NetworkeSpawner : NetworkBehaviour
{
    private void Start()
    {
        // Check if this instance is running as the server
        if (NetworkManager.Singleton.IsServer)
        {
            Debug.Log("door Spawned");
            // Spawn the network object
            NetworkObject networkObject = GetComponent<NetworkObject>();
            networkObject.Spawn();
        }
    }
}

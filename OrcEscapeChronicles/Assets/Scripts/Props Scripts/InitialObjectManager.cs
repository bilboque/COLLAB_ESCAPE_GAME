using Unity.Netcode;
using UnityEngine;

public class InitialObjectManager : NetworkBehaviour
{
    public GameObject[] initialObjects; 

    public override void OnNetworkSpawn()
    {
        if (NetworkManager.Singleton.IsServer)
        {
            foreach (GameObject obj in initialObjects)
            {
                NetworkObject netObj = obj.GetComponent<NetworkObject>();
                if (netObj != null && !netObj.IsSpawned)
                {
                    netObj.Spawn();
                }
            }
        }
    }
}

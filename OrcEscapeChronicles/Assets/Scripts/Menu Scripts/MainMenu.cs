using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Unity.Netcode;
using System;
using JetBrains.Annotations;
using System.Threading;
using Unity.Netcode.Transports.UTP;
public class MainMenu : MonoBehaviour
{

    public void PlayHost()
    {   
        SceneManager.LoadScene(1);
         if (NetworkManager.Singleton != null)
        {
            NetworkManager.Singleton.StartHost();

        }
        else
        {
            Debug.LogError("NetworkManager.Singleton is null. Make sure NetworkManager is present in the scene.");
        }
      
    }
    public void PlayClient()
    {
        SceneManager.LoadScene(1);
        if (NetworkManager.Singleton != null)
        {
            NetworkManager.Singleton.StartClient();
        }
        else
        {
            Debug.LogError("NetworkManager.Singleton is null. Make sure NetworkManager is present in the scene.");
        }

    }
    public void Inputfield(string ip)
    {
         NetworkManager.Singleton.GetComponent<UnityTransport>().SetConnectionData(ip, (ushort)7777);
    }
}

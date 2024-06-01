using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Unity.Netcode;
using System;
using JetBrains.Annotations;
using System.Threading;
using UnityEngine.UI;
using Unity.Netcode.Transports.UTP;
public class MainMenu : MonoBehaviour
{
    public string ip = "127.0.0.1";
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
        NetworkManager.Singleton.GetComponent<UnityTransport>().SetConnectionData(ip,(ushort)7777);
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
    public void IpAdressChanged(string newIpAdress)
    {
        this.ip = newIpAdress;
    }
}

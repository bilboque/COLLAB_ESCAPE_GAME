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
    public void Inputfield()
    {
        var canvas = GameObject.Find("InputField");
        var input = canvas.GetComponent<InputField>();
        if(!input){
            Debug.LogError("InputField not found");
            return;}
        NetworkManager.Singleton.GetComponent<UnityTransport>().SetConnectionData(input.text, (ushort)7777);

    }
      public void SubmitIP(string arg0)
    {
        Debug.Log(arg0);
    }
}

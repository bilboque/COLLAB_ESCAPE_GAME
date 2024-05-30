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
        var input = gameObject.GetComponent<InputField>();
        var se= new InputField.SubmitEvent();
        se.AddListener(SubmitIP);
        NetworkManager.Singleton.GetComponent<UnityTransport>().SetConnectionData(input.onEndEdit.ToString(), (ushort)7777);
    }
      private void SubmitIP(string arg0)
    {
        Debug.Log(arg0);
    }
}

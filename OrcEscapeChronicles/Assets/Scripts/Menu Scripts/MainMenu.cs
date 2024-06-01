using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Unity.Netcode;
using Unity.Netcode.Transports.UTP; // doc de merde
using TMPro;
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

    // Tout les elements de la scene sont des Object qu'on peut trouver avec GameObject.Find.
    // Ensuite il faut acceder au composant du game object
    public void Inputfield()
    {
        var input = GameObject.Find("InputField");
        if (!input)
        {
            Debug.LogError("InputField not found");
            return;
        }
        string ipAddr = input.GetComponent<TMP_InputField>().text;
        // log_input_text(text);

        NetworkManager.Singleton.GetComponent<UnityTransport>().SetConnectionData(
            ipAddr,  // The IP address is a string
            (ushort)7777 // The port number is an unsigned short
        );
    }
    public void SubmitIP(string arg0)
    {
        Debug.Log(arg0);
    }

    void log_input_text(string text)
    {
        Debug.Log(text);
    }
}

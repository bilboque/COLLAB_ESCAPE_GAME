using System.Collections;
using Unity.Netcode;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.Threading.Tasks;
using System;
public class LevelChanger : NetworkBehaviour
{
    public string level;
    public string sortingLayerName;
    public Vector2 position;

    private GameObject player1;
    private GameObject player2;
    private bool player1Ready = false;
    private bool player2Ready = false;

    void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("trigger");
        if (other.CompareTag("Player") && player1==null)
        {
            SceneManager.sceneLoaded += OnSceneLoaded;
            Debug.Log("player 1");
            player1 = other.gameObject;
            player1Ready = true;
            player1.SetActive(false); // Deactivate player1
        }
        else if (other.CompareTag("Player"))
        {
            Debug.Log("player 2");
            player2 = other.gameObject;
            player2Ready = true;
        }
        if (player1Ready && player2Ready) {
            Debug.Log("ready");
            ChangeScene();
        }
    }

    async void ChangeScene()
    {
        await Task.Delay(100);
        if (NetworkManager.Singleton.IsServer)
        {
            NetworkManager.SceneManager.LoadScene(level, LoadSceneMode.Single);
        }
    }
    

    void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        SceneManager.sceneLoaded -= OnSceneLoaded;
        Debug.Log("Loaded");

        if (player1 != null)
        {
            player1.layer = LayerMask.NameToLayer(sortingLayerName);
            player1.GetComponent<SpriteRenderer>().sortingLayerName = sortingLayerName;

            player1.SetActive(true); // Reactivate player1
            player1.transform.position = position;
        }

        if (player2 != null)
        {
            player2.layer = LayerMask.NameToLayer(sortingLayerName);
            player2.GetComponent<SpriteRenderer>().sortingLayerName = sortingLayerName;
            player2.SetActive(true); // Reactivate player2
            player2.transform.position = position;
        }
    }
}

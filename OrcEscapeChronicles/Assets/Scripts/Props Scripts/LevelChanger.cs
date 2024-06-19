using System.Collections;
using Unity.Netcode;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.Threading.Tasks;
using System;

public class LevelChanger : NetworkBehaviour
{
    public int level;
    public string sortingLayerName;
    public Vector2 position;
    public GameObject[] toSpawn;

    private GameObject player1;
    private GameObject player2;
    private NetworkVariable<bool> player1Ready = new NetworkVariable<bool>(false);
    private NetworkVariable<bool> player2Ready = new NetworkVariable<bool>(false);

    [ServerRpc]
    void OnTriggerEnter2DServerRpc(Collider2D other)
    {
        Debug.Log("trigger");
        if (other.CompareTag("Player") && player1==null)
        {
            Debug.Log("player 1");
            player1 = other.gameObject;
            player1Ready.Value = true;
            player1.SetActive(false); // Deactivate player1
        }
        else if (other.CompareTag("Player"))
        {
            Debug.Log("player 2");
            player2 = other.gameObject;
            player2Ready.Value = true;
            player2.SetActive(false); // Deactivate player2
        }
        if (player1Ready.Value && player2Ready.Value) {
            Debug.Log("ready");
            ChangeSceneServerRpc();
        }
    }

    [ServerRpc]
    void ChangeSceneServerRpc()
    {
        Debug.Log("change scene");
        SceneManager.sceneLoaded += OnSceneLoaded;
        SceneManager.LoadScene(level + 1);
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

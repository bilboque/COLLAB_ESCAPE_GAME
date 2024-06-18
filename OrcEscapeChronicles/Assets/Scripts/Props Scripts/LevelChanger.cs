using System.Collections;
using Unity.Netcode;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelChanger : NetworkBehaviour
{
    public int level;
    public string sortingLayerName;
    public Vector2 position;

    private GameObject player1;
    private GameObject player2;
    private bool player1Ready = false;
    private bool player2Ready = false;

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player") && player1==null)
        {
            player1 = other.gameObject;
            player1Ready = true;
            player1.SetActive(false); // Deactivate player1
        }
        else if (other.CompareTag("Player"))
        {
            player2 = other.gameObject;
            player2Ready = true;
            player2.SetActive(false); // Deactivate player2
        }
        if (player1Ready && player2Ready)
            changeScene();
    }

    void changeScene()
    {
        SceneManager.sceneLoaded += OnSceneLoaded;
        SceneManager.LoadScene(level + 1);
    }

    void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        SceneManager.sceneLoaded -= OnSceneLoaded;

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

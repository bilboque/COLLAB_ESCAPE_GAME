using System.Collections;
using System.Collections.Generic;
using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelChanger : MonoBehaviour
{
    public int level;
    public string sortingLayerName;
    public Vector2 position;
    void OnTriggerExit2D(Collider2D other){

        other.gameObject.layer = LayerMask.NameToLayer(sortingLayerName);
        other.gameObject.GetComponent<SpriteRenderer>().sortingLayerName = sortingLayerName;
        SceneManager.LoadScene(level + 1);
        other.gameObject.GetComponent<Rigidbody2D>().MovePosition(position);
    }
    
}

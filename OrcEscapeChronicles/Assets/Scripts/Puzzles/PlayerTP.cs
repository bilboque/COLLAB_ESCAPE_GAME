using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerTP : MonoBehaviour
{
    public Vector2 position;

    void OnTriggerEnter2D(Collider2D other){
        other.transform.position = position;
    }
}

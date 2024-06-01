using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interactable : MonoBehaviour
{
    public virtual void Interact()
    {
        // Override this method in derived classes
        Debug.Log("Interacted with " + gameObject.name);
    }
}
using System.Collections;
using System.Collections.Generic;
using Unity.Netcode;
using UnityEngine;

public class Interactable : NetworkBehaviour
{

    public virtual void Interact()
    {
        // Override this method in derived classes
        Debug.Log("Interacted with " + gameObject.name);
    }
}
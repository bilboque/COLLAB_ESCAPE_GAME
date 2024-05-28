using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Netcode;

public class PlayerBodyTypeManager : NetworkBehaviour
{
    private Rigidbody2D rb;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    public override void OnNetworkSpawn()
    {
        base.OnNetworkSpawn();
        
        // Ensure this runs only on the owner client
        if (IsOwner)
        {
            // Set the Rigidbody2D body type to Dynamic
            SetBodyTypeToDynamic();
        }
    }

    public void SetBodyTypeToDynamic()
    {
        if (rb != null)
        {
            rb.bodyType = RigidbodyType2D.Dynamic;
        }
    }
}


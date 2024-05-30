using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Netcode;
using Unity.VisualScripting;

public class PlayerBodyTypeManager : NetworkBehaviour
{
    private Rigidbody2D rb;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        DontDestroyOnLoad(gameObject);
    }

    public override void OnNetworkSpawn()
    {
        base.OnNetworkSpawn();
        var cameraObject = GameObject.Find("CameraController");
        cameraController camera = cameraObject.GetComponent<cameraController>();
        
        var transform = GetComponent<Transform>();
        
        // Ensure this runs only on the owner client
        if (IsOwner)
        {
            // Set the Rigidbody2D body type to Dynamic
            SetBodyTypeToDynamic();
            camera.AddTarget(transform);
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


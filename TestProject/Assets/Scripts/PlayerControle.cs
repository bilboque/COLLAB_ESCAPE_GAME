using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Netcode;

public class PlayerControle : NetworkBehaviour
{
    public float moveSpeed = 1f;  // Vitesse de déplacement du joueur
    private Rigidbody2D rb;  // Référence au Rigidbody2D du joueur
    private Vector2 movement;  // Vecteur de mouvement
    
    // Start is called before the first frame update
    void Start()
    {
       rb = GetComponent<Rigidbody2D>(); 
    }

    // Update is called once per frame
    void Update()
    {
       if(!IsOwner) return;
       movement.x = Input.GetAxisRaw("Horizontal"); 
       movement.y = Input.GetAxisRaw("Vertical");
    }

    void FixedUpdate()
    {
       if(!IsOwner) return;
       rb.MovePosition(rb.position + movement * moveSpeed * Time.fixedDeltaTime);
    }
}

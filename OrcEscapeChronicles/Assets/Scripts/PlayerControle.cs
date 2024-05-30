using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Netcode;

public class PlayerControle : NetworkBehaviour
{
    public float moveSpeed = 1f;  // Vitesse de déplacement du joueur
    private Rigidbody2D rb;  // Référence au Rigidbody2D du joueur
    private Vector2 movement;  // Vecteur de mouvement

    private Animator animator;
    
    // Start is called before the first frame update
    void Start()
    {
       rb = GetComponent<Rigidbody2D>(); 
       animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
       const int up = 1;
       const int down = 0;
       const int left = 3;
       const int wright = 2;


       if(!IsOwner) return;
       movement.x = Input.GetAxisRaw("Horizontal"); 
       movement.y = Input.GetAxisRaw("Vertical");

      if (movement.x > 0)
      {
         animator.SetInteger("Direction", wright);
      }
      else if (movement.x < 0)
      {
         animator.SetInteger("Direction", left);
      }

      if (movement.y > 0)
      {
         animator.SetInteger("Direction", up);
      }
      else if (movement.y < 0)
      {
         animator.SetInteger("Direction", down);
      }
      animator.SetBool("IsMoving", movement.magnitude > 0);
   }

   void FixedUpdate()
    {
       if(!IsOwner) return;
       rb.MovePosition(rb.position + movement * moveSpeed * Time.fixedDeltaTime);
    }
}

using System.Collections;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] float movementSpeedBase = 5;

    private Animator animator;
    private Rigidbody2D rb;
    private float movementSpeedMultiplier;
    private Vector2 currentMoveDirection;
    public int playerScore;

    void Start()
    {
        animator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        Move();
        if(Input.GetMouseButtonDown(1))
        {
            if(Random.Range(0f, 1.0f) > 0.5f)
                animator.SetTrigger("attack");
            else
                animator.SetTrigger("special");
        }
    }

    private void Move()
    {
        Vector2 movementDirection = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));

        Vector2 moveVector = movementDirection.normalized * movementSpeedBase * movementSpeedMultiplier;

        animator.SetFloat("Speed", moveVector.magnitude);
        rb.velocity = moveVector;

        if (moveVector != Vector2.zero)
        {
            currentMoveDirection = new Vector2(moveVector.normalized.x, moveVector.normalized.y);
            animator.SetFloat("Horizontal", moveVector.normalized.x);
            animator.SetFloat("Vertical", moveVector.normalized.y);
        }
    }

}
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed;
    public Rigidbody2D rigidBody2D;
    public Animator animator;


    private Vector2 moveDirection;
    private float moveX, moveY;
    private bool isMovingRight = false;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        moveX = Input.GetAxisRaw("Horizontal");
        moveY = Input.GetAxisRaw("Vertical");

        moveDirection = new Vector2(moveX, moveY).normalized;

        // Flip for Moving Right and Left
        if ((moveDirection.x > 0 && !isMovingRight) || (moveDirection.x < 0 && isMovingRight)) Flip();

        if (moveDirection.x == 0 && moveDirection.y == 0) animator.SetBool("isWalking", false);
        else animator.SetBool("isWalking", true);
    }

    void FixedUpdate()
    {
        rigidBody2D.velocity = new Vector2(moveDirection.x * moveSpeed, moveDirection.y * moveSpeed);
    }

    void Flip()
    {
        isMovingRight = !isMovingRight;
        transform.localScale = new Vector3(transform.localScale.x * -1, transform.localScale.y, transform.localScale.z);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemigoController : MonoBehaviour
{
    private Rigidbody2D rb;
    public MovementController movementController;
    private Animator animator;
    SpriteRenderer sr;
    private int currentAnimation = 1;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        sr = GetComponent<SpriteRenderer>();
        sr.flipX = true;
        InvokeRepeating("MoveAnim", 0.0f, 2.0f);
    }

    // Update is called once per frame
    void Update()
    {
        animator.SetInteger("EnemyAnim", currentAnimation);
    }

    public void MoveAnim()
    {
        if (movementController.stopEnemy)
        {
            rb.velocity = new Vector2(0, rb.velocity.y);
            currentAnimation = 1;
        }
        else
        {
            rb.velocity = new Vector2(-10, rb.velocity.y);
            currentAnimation = 2;
        }


    }
}

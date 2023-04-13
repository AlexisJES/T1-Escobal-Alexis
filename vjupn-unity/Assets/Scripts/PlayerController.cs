using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float xVelocity = 10f;
    private int currentAnimation = 1;

    private Rigidbody2D rb;
    private Animator animator;
    SpriteRenderer sr;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        sr = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        currentAnimation = 1;

        if (Input.GetKey(KeyCode.RightArrow))
        {
            currentAnimation = 2;
            sr.flipX = false;
        }

        if (Input.GetKey(KeyCode.LeftArrow))
        {
            currentAnimation = 2;
            sr.flipX = true;
        }


        animator.SetInteger("AnimState", currentAnimation);
    }
}

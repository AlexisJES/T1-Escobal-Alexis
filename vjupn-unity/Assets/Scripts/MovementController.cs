using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementController : MonoBehaviour
{
    public FootController footController;
    public LateralesController sidesContoller;
    public float jumpForce = 10000f;
    private Rigidbody2D rb;

    // Common moves
    public float xVelocity = 10f;
    public float bootVel = .0f;

    // Jump variables
    private bool superJump = false;
    private const float BOOST_JUMP = 1.7f;
    public const int MAX_JUMPS = 2;
    bool doubleJump = false;
    public bool stopEnemy = false;


    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();

    }

    // Update is called once per frame
    void Update()
    {
        if (stopEnemy)
        {
            // Die
            return;
        }


        // Common moves
        float yVelocity = rb.velocity.y;
        rb.velocity = new Vector2(0, yVelocity);

        if (Input.GetKey(KeyCode.RightArrow))
        {
            rb.velocity = new Vector2(xVelocity + bootVel, yVelocity);
        }

        if (Input.GetKey(KeyCode.LeftArrow))
        {
            rb.velocity = new Vector2(-xVelocity - bootVel, yVelocity);
        }


        // Jump logic
        bool canJump = (footController.CanJump() && !sidesContoller.CanJump()) ||
                       (footController.CanJump() && sidesContoller.CanJump()) ||
                       (!footController.CanJump() && sidesContoller.CanJump());

        if (Input.GetKeyUp(KeyCode.Space) && canJump)
        {
            this.Jump(this.jumpForce);
            Debug.Log("Normal Jump");
        }

        if (Input.GetKeyUp(KeyCode.UpArrow) && superJump && canJump)
        {
            this.Jump(this.jumpForce);
            Debug.Log("Super Jump");
            superJump = false;
            doubleJump = true;
        }

        if (Input.GetKeyUp(KeyCode.Space) && doubleJump && !footController.onGround)
        {
            Debug.Log("Second Jump");
            if (footController.CanJump())
                doubleJump = false;

            else
                this.Jump(this.jumpForce * BOOST_JUMP);

            doubleJump = false;
        }


    }

    private void Jump(float jumpForce)
    {
        rb.AddForce(transform.up * jumpForce);
        footController.Jump();
        sidesContoller.Jump();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            Debug.Log("Has chocado un enemigo");
            stopEnemy = true;
        }

        if (collision.gameObject.CompareTag("AddVel"))
        {
            this.bootVel += 5;
            Debug.Log("vel added");
        }
    }


    private void OnTriggerEnter2D(Collider2D other)
    {

        if (other.gameObject.CompareTag("BoostJump"))
        {
            other.gameObject.SetActive(false);
            superJump = true;
            
        }

    }
}

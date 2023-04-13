using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FootController : MonoBehaviour
{
    public const int MAX_JUMPS = 2;
    public bool onGround = false;
    //private int currentJumps = 0;

    public bool CanJump()
    {
        return onGround;
    }

    public void Jump()
    {
        onGround = false;
    }


    void OnCollisionEnter2D(Collision2D other)
    {
        onGround = true;
        Debug.Log("Now, He can jump");
    }
}

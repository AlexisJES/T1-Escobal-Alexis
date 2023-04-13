using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LateralesController : MonoBehaviour
{
    public bool WallCollition { get; set; } = false;

    public bool CanJump()
    {
        return WallCollition;
    }

    public void Jump()
    {
        this.WallCollition = false;
    }

    public void OnCollisionStay2D(Collision2D collision)
    {
        Debug.Log("He's next to wall");
        WallCollition = true;
    }
}

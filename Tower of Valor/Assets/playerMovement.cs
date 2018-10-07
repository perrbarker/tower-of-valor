using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerMovement : MonoBehaviour
{

    public float moveSpeed;
    public float jumpHeight;
    private float moveVelocity, jumpVelocity;   // determines speed and direction of movement
    public KeyCode left, right, jump;   // player controls
    private Rigidbody2D body;
    public bool canJump;

    // Use this for initialization
    void Start()
    {
        body = gameObject.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {

        moveVelocity = 0f;

        // Horizontal movement
        if (Input.GetKey(left))
        {
            moveVelocity = -moveSpeed;
        }
        if (Input.GetKey(right))
        {
            moveVelocity = moveSpeed;
        }

        // Jump
        if (Input.GetKeyDown(jump))
        {
            if (Grounded())
            {
                canJump = true;
            }
        }
    }

    // Do physics stuff
    void FixedUpdate()
    {
        Movement();

        if (canJump)
        {
            Jump();
            canJump = false;
        }
    }

    void Movement()
    {
        body.velocity = new Vector2(moveVelocity, body.velocity.y);
    }

    void Jump()
    {
        body.velocity = new Vector2(0, jumpHeight);
    }

    // Check if object's y velocity is 0
    public bool Grounded()
    {
        // round down
        if (Mathf.Round(body.velocity.y) == 0f)
        {
            return true;
        }
        else
            return false;
    }
}
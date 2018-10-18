using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerMovement : MonoBehaviour
{

    public float moveSpeed;
    public float jumpHeight;
    private float moveVelocity, jumpVelocity; // determines speed and direction of movement
    public bool movingLeft;    // checks to see which direction the player was previously moving
    public KeyCode left, right, jump; // player controls
    private Rigidbody2D body;
    public float slowDownForce; // determines how quick player movement stops

    public Transform Lfeet, Rfeet;
    public float range;
    public bool grounded;
    public bool canJump; // jump enabler
    public bool doubleJump; // doublejump enabler
    public bool powerDoubleJump; // doublejump powerup

    // Use this for initialization
    void Start()
    {
        body = gameObject.GetComponent<Rigidbody2D>();

    }

    // Update is called once per frame
    void Update()
    {

        SlowDown();

        // Horizontal movement
        if (Input.GetKey(right) && Input.GetKey(left))  // if player is holding both left and right key
        {
            if (movingLeft == false)
            {
                moveVelocity = -moveSpeed;
            }
            else
            {
                moveVelocity = moveSpeed;
            }
        }
        else if (Input.GetKey(left))
        {
            moveVelocity = -moveSpeed;
            movingLeft = true;
        }
        else if (Input.GetKey(right))
        {
            moveVelocity = +moveSpeed;
            movingLeft = false;
        }
       

        // Jump
        if (Input.GetKeyDown(jump))
        {
            checkRayCastHit();

            if (grounded)
            {
                Jump();
            }
            // in air
            else
            {
                if (doubleJump && powerDoubleJump)
                {
                    Jump();
                    doubleJump = false;
                }
            }
        }
    }

    // Do physics stuff
    void FixedUpdate()
    {
        Movement();       
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        // only check raycast when it hits something for improved performance, maybe ? ??
        checkRayCastHit();
    }

    void checkRayCastHit()
    {
        Debug.DrawRay(Lfeet.position, Vector2.down * range);
        Debug.DrawRay(Rfeet.position, Vector2.down * range);

        // Fires a ray at feet position downwards to see if it hits(collides) with an object
        RaycastHit2D LfeetHit = Physics2D.Raycast(Lfeet.position, Vector2.down, range);
        RaycastHit2D RfeetHit = Physics2D.Raycast(Rfeet.position, Vector2.down, range);
        // check if one of the foot hits something
        if (LfeetHit == true || RfeetHit == true)
        {
           // Debug.Log("Hit one feet");
            grounded = true;
            doubleJump = true;
        }
        else
        {
            grounded = false;
        }
    }

    // Slows down player velocity to 0 over time
    void SlowDown()
    {
        moveVelocity = Mathf.MoveTowards(moveVelocity, 0f, slowDownForce * Time.deltaTime);
    }

    void Movement()
    {
        body.velocity = new Vector2(moveVelocity, body.velocity.y);
    }

    void Jump()
    {
        body.velocity = new Vector2(0, jumpHeight);
        grounded = false;
        doubleJump = true;
    }

}
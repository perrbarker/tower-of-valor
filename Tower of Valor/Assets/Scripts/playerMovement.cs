using UnityEngine;

public class playerMovement : MonoBehaviour
{

    public float moveSpeed;
    private float moveVelocity; // determines speed and direction of movement
    public bool movingLeft;    // checks to see which direction the player was previously moving
    public KeyCode left, right;
    private Rigidbody2D body;
    public float slowDownForce; // determines how quick player movement stops

	public Animator animation;

    // Use this for initialization
    void Start()
    {
        body = gameObject.GetComponent<Rigidbody2D>();

    }

    // Update is called once per frame
    void Update()
    {
        SlowDown();
	
		animation.SetFloat ("Speed", moveVelocity);

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
        else if (Input.GetKey(left)) // move left
        {
            moveVelocity = -moveSpeed;
            movingLeft = true;
        }
        else if (Input.GetKey(right)) // move right
        {
            moveVelocity = +moveSpeed;
            movingLeft = false;
        }
       
    }

    // Do physics stuff
    void FixedUpdate()
    {
        Movement();       
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

}
using UnityEngine;

public class Throwable : MonoBehaviour {

    public bool isGrabbed;
    public bool isThrown;
    public KeyCode left, right;
    public int maxStruggle;
    private static int strugglePoints;
    private Rigidbody2D body;

    void Start()
    {
        body = GetComponent<Rigidbody2D>();
    }

    void Update () {

        if (isGrabbed)
        {
            DisableMovement();
        }

        if (isGrabbed)
        {
            Struggle();
        }

	}

    // player can press keys x amount of times to get out of grab
    void Struggle()
    {
        if (Input.GetKeyDown(left))
        {
            body.velocity = new Vector2(-5, body.velocity.y);
            strugglePoints++;
        }
        if (Input.GetKeyDown(right))
        {
            body.velocity = new Vector2(5, body.velocity.y);
            strugglePoints++;
        }

        // acquired enough struggle points to escape grab
        if (strugglePoints >= maxStruggle)
        {
            isGrabbed = false;
            GetComponent<playerMovement>().enabled = true;

            // jumps a bit
            body.velocity = new Vector2(0, 10);

        }
    }

    // disable movement script
    void DisableMovement()
    {
        gameObject.GetComponent<playerMovement>().enabled = false;  
    }

    // Object regains movement if collided with something after being thrown
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (isThrown)
        {
            GetComponent<playerMovement>().enabled = true;   // enable movement script
            isThrown = false;
        }

    }

    public void ResetStrugglePoints()
    {
        strugglePoints = 0;
    }
}

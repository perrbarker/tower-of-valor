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
            Struggle();
			if (gameObject.tag == "Player")
			{
				DisableMovement ();
			}
        }
    }

    void LateUpdate()
    {
        if (strugglePoints >= maxStruggle)
        {
            EnableMovement();
        }

    }

    // player can press keys x amount of times to get out of grab
    void Struggle()
    {
        if (Input.GetKeyDown(left))
        {
            body.velocity = new Vector2(-1, body.velocity.y);
            strugglePoints++;
        }
        if (Input.GetKeyDown(right))
        {
            body.velocity = new Vector2(1, body.velocity.y);
            strugglePoints++;
        }

        // acquired enough struggle points to escape grab
        if (strugglePoints >= maxStruggle)
        {
            // jumps a bit
            body.velocity = new Vector2(body.velocity.x, 10);

            isGrabbed = false;

			if (gameObject.tag == "Player")
			{
				EnableMovement ();
			}
        }
    }

    // disable movement script
    public void DisableMovement()
    {
        GetComponent<playerMovement>().enabled = false; 
		GetComponent<Jump> ().enabled = false;
    }

    public void EnableMovement()
    {
		if (gameObject.GetComponent ("playerMovement") as playerMovement != null)
		{
			GetComponent<playerMovement> ().enabled = true;
			GetComponent<Rigidbody2D> ().constraints = RigidbodyConstraints2D.FreezeRotation;
			GetComponent<Jump>().enabled = true;
			GetComponent<Rigidbody2D> ().mass = 1;
		}

    }



    // Object regains movement if collided with something after being thrown
    void OnCollisionEnter2D(Collision2D collision)
    {

        /*
        if (collision.transform.tag == "Platform")
        {
            isGrabbed = false;
            EnableMovement();
        }
        */

        if (isThrown)
        {
            EnableMovement();
            isThrown = false;
            GetComponent<Rigidbody2D>().mass = 1;
        }
    }


    public void ResetStrugglePoints()
    {
        strugglePoints = 0;
    }
}

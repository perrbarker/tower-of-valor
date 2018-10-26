using UnityEngine;

public class Jump : MonoBehaviour {

    public KeyCode jump;
    public float jumpHeight;
    private Rigidbody2D body;
    private float range = .3f;

    private bool isGrounded;
    private bool canJump;
    private bool canDoubleJump;
    public bool doubleJumpPower;

    public BoxCollider2D leftFootCollider;
    public BoxCollider2D RightFootCollider;

    // Use this for initialization
    void Start () {
        body = GetComponent<Rigidbody2D>();
        canJump = true;
	}
	
	// Update is called once per frame
	void LateUpdate () {

        if (Input.GetKeyDown(jump))
        {
            if (isGrounded)
            {
                // Jump
                body.velocity = new Vector2(0, jumpHeight);
                isGrounded = false;
            }
            // on air
            else
            {
                if (canDoubleJump && doubleJumpPower)
                {
                    // Jump
                    body.velocity = new Vector2(0, jumpHeight);
                    canDoubleJump = false;
                }
            }
        }
    }

    // While Colliding with object
    void OnCollisionStay2D(Collision2D collision)
    {
        Debug.Log("ENTER");

        // check if feet colliders collision
        if (leftFootCollider.IsTouching(collision.collider) || RightFootCollider.IsTouching(collision.collider))
        {
            isGrounded = true;
            canDoubleJump = true;
        }

    }

    // When Object doesn't collide anymore
    void OnCollisionExit2D(Collision2D collision)
    {
        isGrounded = false;
    }
}

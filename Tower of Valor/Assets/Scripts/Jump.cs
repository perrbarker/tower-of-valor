using System.Collections;
using UnityEngine;

public class Jump : MonoBehaviour {

    public KeyCode jump;
    public float jumpHeight;
    private Rigidbody2D body;

    public bool isGrounded;
    public bool canJump;
    public bool canDoubleJump;
    public bool doubleJumpPower;

    public PolygonCollider2D leftFootCollider;
    public PolygonCollider2D RightFootCollider;

    // Use this for initialization
    void Start () {
        body = GetComponent<Rigidbody2D>();
        canJump = true;
	}
	
	// Update is called once per frame
	void LateUpdate () {

        if (Input.GetKey(jump))
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

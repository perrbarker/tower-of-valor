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
                body.velocity = new Vector2(body.velocity.x, jumpHeight);
                isGrounded = false;
            }
            // on air
            else
            {
                if (canDoubleJump && doubleJumpPower)
                {
                    // Jump
                    body.velocity = new Vector2(body.velocity.x, jumpHeight);
                    canDoubleJump = false;
                }
            }
        }
    }

    /** While Colliding with object -- should check if lands on enemy
										if bat, kill bat
										else if enemy, player takes 1 damage
	**/
	void OnCollisionEnter2D(Collision2D col)
	{
		if (col.collider.gameObject.GetComponent<Enemy> ().isBat)
		{
			if (leftFootCollider.IsTouching (col.collider) || RightFootCollider.IsTouching (col.collider))
			{
				gameObject.GetComponent<Health> ().removeHitPoints (-1);
				col.collider.gameObject.GetComponent<Health> ().removeHitPoints (1);
			}
		}
		else
		{
			isGrounded = true;
			canDoubleJump = false;
		}
	}
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

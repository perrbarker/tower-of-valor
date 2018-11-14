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

    public Transform leftFoot, rightFoot, leftHeel, rightHeel;

    private RaycastHit2D hitLeftFoot, hitLeftHeel, hitRightFoot, hitRightHeel;

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

        // Check if gameobject has an Enemy script
        if (col.gameObject.GetComponent("Enemy") as Enemy != null)
        {
            // Check if Enemy is bat
            if (col.collider.gameObject.GetComponent<Enemy>().isBat)
            {
                CheckBottomRaycast();
                if (hitLeftFoot == true || hitRightFoot == true || hitLeftHeel == true || hitRightFoot == true)
                {
                    gameObject.GetComponent<Health>().removeHitPoints(-1);
                    col.collider.gameObject.GetComponent<Health>().removeHitPoints(1);
                }
            }

        }

		else
		{
            CheckBottomRaycast();
            if (hitLeftFoot == true || hitRightFoot == true || hitLeftHeel == true || hitRightFoot == true)
            {
                isGrounded = true;
                canDoubleJump = false;
            }
		}
	}
    void OnCollisionStay2D(Collision2D collision)
    {
        CheckBottomRaycast();
        if (hitLeftFoot == true || hitRightFoot == true || hitLeftHeel == true || hitRightFoot == true )
        {
            isGrounded = true;
            canDoubleJump = true;
        }

    }

    // Cast 4 downward raycasts on all 4 feet and heel positions
    void CheckBottomRaycast()
    {       
        // check if bottom collider rays hit something
        hitLeftFoot = Physics2D.Raycast(leftFoot.position, Vector2.down, .1f);
        hitRightFoot = Physics2D.Raycast(rightFoot.position, Vector2.down, .1f);
        hitLeftHeel = Physics2D.Raycast(leftHeel.position, Vector2.down, .1f);
        hitRightFoot = Physics2D.Raycast(rightHeel.position, Vector2.down, .1f);
    }

    // When Object doesn't collide anymore
    void OnCollisionExit2D(Collision2D collision)
    {
        isGrounded = false;
    }

}

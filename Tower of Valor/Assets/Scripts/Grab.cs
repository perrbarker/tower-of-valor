using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Grabs, hold, and toss other gameObject
public class Grab : MonoBehaviour {

    private Vector3 vecDir;
    private Vector2 vecSide;
    public KeyCode grab;
    public float grabRange;
    public Transform holdPosition;
    public bool isHolding;
    private GameObject grabbedObject;

    public float throwForce;
    public float angle;
    private Vector3 directionThrow;
    public bool facingLeft;


    // Update is called once per frame
    void Update () {

		if (Input.GetKeyUp(grab))
        {
            // grab
            if (!isHolding)
            {
                CheckRayCastHit();
            }
            else
            {
                Throw();
            }
        }



    }

    void FixedUpdate()
    {
        // check if enemy escaped
        if (grabbedObject != null)
        {
            if (grabbedObject.GetComponent<Throwable>().isGrabbed == false)
            {
                isHolding = false;
            }
        }

        if (isHolding)
        {
            if (grabbedObject != null)
            {
                grabbedObject.transform.position = holdPosition.position;
            }
        }

    }

    void CheckRayCastHit()
    {
        CheckDirFacing();


        // Cast two rays above player to check if there is a platform
        Vector2 vecTop1 = transform.position + new Vector3(-.5f, 1f, 0);
        Vector2 vecTop2 = transform.position + new Vector3(.5f, 1f, 0);

        Debug.DrawRay(vecTop1, Vector3.up * grabRange);
        Debug.DrawRay(vecTop2, Vector3.up * grabRange);

        RaycastHit2D hitTop1 = Physics2D.Raycast(vecTop1, Vector3.up, grabRange);
        RaycastHit2D hitTop2 = Physics2D.Raycast(vecTop2, Vector3.up, grabRange);

        // If there is a platform above you, do nothing (do not grab)
        if (hitTop1 == true)
        {
            if (hitTop1.transform.tag == "Platform")
            {
                return;
            }
        }
        if (hitTop2 == true)
        {
            if (hitTop2.transform.tag == "Platform")
            {
                return;
            }
        }

        // Set which direction to cast ray
        if (facingLeft)
        {
            vecSide = transform.position + new Vector3(-.65f, 0f, 0f);
            vecDir = Vector2.left;
        }
        else
        {
            vecSide = transform.position + new Vector3(.65f, 0f, 0f);
            vecDir = Vector2.right;
        }


        // cast ray
        Debug.DrawRay(vecSide, vecDir * grabRange);
        RaycastHit2D hit = Physics2D.Raycast(vecSide, vecDir, grabRange);

        if (hit == true)
        {
            if (hit.transform.tag == "Player")
            {
                Debug.Log("Hit player");
                grabbedObject = hit.transform.gameObject;
                isHolding = true;

                grabbedObject.GetComponent<Throwable>().isGrabbed = true;
                grabbedObject.GetComponent<Rigidbody2D>().mass = .01f;
                grabbedObject.GetComponent<Throwable>().ResetStrugglePoints();


            }
			else if(hit.collider.gameObject.GetComponent<Enemy>().isGargoyle)
			{
				Debug.Log ("Hit Gargoyle");

				gameObject.GetComponent<Health> ().removeHitPoints (-1);
				grabbedObject = hit.transform.gameObject;
				isHolding = true;

				grabbedObject.GetComponent<Enemy> ().animator.enabled = false;
				grabbedObject.GetComponent<Throwable> ().isGrabbed = true;
				grabbedObject.GetComponent<Rigidbody2D> ().mass = .01f;
				grabbedObject.GetComponent<Throwable> ().ResetStrugglePoints ();
			}
        }       
    }



    void Throw()
    {
        Debug.Log("THROW");
        CheckDirFacing();

        //  left
        if (facingLeft)
        {
            directionThrow = Quaternion.AngleAxis(angle, Vector3.back) * Vector3.left;
        }
        //  right
        else if (!facingLeft)
        {
            directionThrow = Quaternion.AngleAxis(angle, Vector3.forward) * Vector3.right;
        }

        // throw at direction throw
        isHolding = false;

        grabbedObject.GetComponent<Throwable>().isGrabbed = false;
        grabbedObject.GetComponent<Throwable>().isThrown = true;

        grabbedObject.GetComponent<Rigidbody2D>().AddForce(directionThrow * throwForce);

		if (grabbedObject.GetComponent<Enemy> ().isGargoyle)
		{
			grabbedObject.GetComponent<Health> ().removeHitPoints (1);
		}

    }


    void CheckDirFacing()
    {
        facingLeft = GetComponent<playerMovement>().movingLeft; // set direction facing
    }

}

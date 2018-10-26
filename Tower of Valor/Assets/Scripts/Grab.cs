using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Grabs, hold, and toss other gameObject
// TODO: need to determine which direction is facing
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
            // toss
            else
            {
                Throw();
            }

        }

    }

    void FixedUpdate()
    {
        if (isHolding)
        {
            grabbedObject.transform.position = holdPosition.position;
        }

        // check if enemy escaped
        if (grabbedObject != null)
        {
            if (grabbedObject.GetComponent<Throwable>().isGrabbed == false)
            {
                isHolding = false;
            }
        }

    }

    void CheckRayCastHit()
    {
        CheckDirFacing();

        // Set which direction to cast ray
        if (facingLeft)
        {
            vecSide = transform.position + new Vector3(-1.25f, 0f, 0f);
            vecDir = Vector2.left;
        }
        else
        {
            vecSide = transform.position + new Vector3(1.25f, 0f, 0f);
            vecDir = Vector2.right;
        }


        //Debug.DrawRay(vecSide, vecDir * grabRange);

        // cast ray
        RaycastHit2D hit = Physics2D.Raycast(vecSide, vecDir, grabRange);
        if (hit == true)
        {
            if (hit.transform.tag == "Player")
            {
                grabbedObject = hit.collider.gameObject;
                isHolding = true;
                grabbedObject.GetComponent<Throwable>().isGrabbed = true;
                grabbedObject.GetComponent<Throwable>().ResetStrugglePoints();
            }
        }       
    }

    void Throw()
    {
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


    }

    void CheckDirFacing()
    {
        facingLeft = GetComponent<playerMovement>().movingLeft; // set direction facing
    }

}

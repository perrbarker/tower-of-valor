using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Grabs, hold, and toss other gameObject
// TODO: need to determine which direction is facing
public class Grab : MonoBehaviour {

    private Vector3 vecRight;
    public KeyCode grab;
    public float grabRange;
    public Transform holdPosition;
    public bool isGrab;
    private Transform grabbedObject;

    public float throwForce;
    public float angle;
    private Vector3 directionThrow;


	// Use this for initialization
	void Start () {
        directionThrow = Quaternion.AngleAxis(angle, Vector3.forward) * Vector3.right;
    }
	
	// Update is called once per frame
	void Update () {

		if (Input.GetKeyUp(grab))
        {
            // grab
            if (!isGrab)
            {
                CheckRayCastHit();
            }
            // toss
            else
            {
                isGrab = false;
                grabbedObject.GetComponent<Rigidbody2D>().AddForce(directionThrow * throwForce);
                StartCoroutine("DisableMovement");
            }

        }

       
	}

    void FixedUpdate()
    {
        if (isGrab)
        {
            grabbedObject.position = holdPosition.position;
        }
    }

    void CheckRayCastHit()
    {
        // Right vector position of object
        vecRight = transform.position + new Vector3(.5f, 0f, 0f);

        Debug.DrawRay(vecRight , Vector2.right * grabRange);

        // fire ray at right
        RaycastHit2D hit = Physics2D.Raycast(vecRight, Vector2.right, grabRange);
        if (hit == true)
        {
            if (hit.transform.tag == "Player")
            {
                grabbedObject = hit.transform;
                isGrab = true;
            }
        }       
    }


    IEnumerator DisableMovement()
    {
        grabbedObject.GetComponent<playerMovement>().enabled = false;
        yield return new WaitForSeconds(1f);
        grabbedObject.GetComponent<playerMovement>().enabled = true;

    }

}

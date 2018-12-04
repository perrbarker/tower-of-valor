using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallingPlatforms : MonoBehaviour 
{
	Rigidbody2D rb;
    public float fallTimer;
    private GameObject p1;

	// Use this for initialization
	void Start () 
	{
		rb = GetComponent<Rigidbody2D> ();
	}
	
	void OnCollisionEnter2D (Collision2D col)
	{
		if (col.gameObject.tag == "Player")
		{
            //Debug.Log("collided with player test 1");
            //p1 = col.gameObject;
            //if (col.collider.GetComponent<Jump>().isGrounded == true)
            {
                //Debug.Log("collided with player test 2");
                //print("FallingPlatforms");
                Invoke("DropPlatform", fallTimer);
                Destroy(gameObject, 2f);
				FindObjectOfType<AudioManager>().Play("DroppingPlatform");
            }
		}
	}

	void DropPlatform()
	{
		rb.isKinematic = false;
	}
}

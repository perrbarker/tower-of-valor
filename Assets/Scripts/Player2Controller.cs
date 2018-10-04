using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

    public float moveSpeed;
    public float moveVelocity;
    public float jumpHeight;
    private Rigidbody2D body;

	// Use this for initialization
	void Start () {
        body = GetComponent<Rigidbody2D>();
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown (KeyCode.Space))
        {
            body.velocity = new Vector2(0, jumpHeight);
        }

        moveVelocity = 0f;

        if (Input.GetKey(KeyCode.D))
        {
            moveVelocity = moveSpeed;
        }
        if (Input.GetKey(KeyCode.A))
        {
            moveVelocity = -moveSpeed;
        }

        body.velocity = new Vector2(moveVelocity, body.velocity.y);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraScript : MonoBehaviour {

    public Transform player1, player2;
    public Vector3 offset;

	// Use this for initialization
	void Start () {
        transform.position = offset;
	}
	
	// Update is called once per frame
	void Update () {

        // only follow in y axis
        Vector3 posY = new Vector3(0, higherPlayer().position.y, 0);
        transform.position = posY + offset;
	}

    // check which player has higher height
    public Transform higherPlayer()
    {
        if (player1.position.y >= player2.position.y)
        {
            return player1;
        }
        else
        {
            return player2;
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Leap_Frog : MonoBehaviour {

	public Transform tile_1, tile_2, camPosy; // position of tile
	public Vector3 offset; // starting position of each tile
	public float Y_MOVE;
	public float OVERLAP; // distance to move each tile
	public float t1Pos, t2Pos;

	// Use this for initialization
	void Start () {
		//tile_1.transform.position = offset;
		//tile_2.transform.position = new Vector3(0f, X_SCALE, 0f);
		t1Pos = tile_1.position.y;
		t2Pos = tile_2.position.y;
	}
	
	// update the position of the background tiles in relation to the camera
	void Update () {

		// camera is above tile 1, player is in front of tile 2
		if (camPosy.transform.position.y >= tile_1.transform.position.y + OVERLAP) {
			Debug.Log ("Moving Background: tile1 up");
			t1Pos += Y_MOVE;
			tile_1.transform.position = new Vector3(0, t1Pos, 0);
		}
		// camera is above tile 2, player is in front of tile 1
		else if (camPosy.transform.position.y >= tile_2.transform.position.y + OVERLAP) {
			Debug.Log ("Moving Background: tile2 up");
			t2Pos += Y_MOVE;
			tile_2.transform.position = new Vector3(0, t2Pos, 0);
		}
		// camera is below tile 1, player is in front of tile 2
		else if (camPosy.transform.position.y < tile_2.transform.position.y - OVERLAP/2 && t1Pos > t2Pos) {
			Debug.Log ("Moving Background: tile1 down");
			t1Pos -= Y_MOVE;
			tile_1.transform.position = new Vector3(0, t1Pos, 0);
		}
		// camera is below tile 1, and tile 1 is the lower
		else if (camPosy.transform.position.y < tile_1.transform.position.y - OVERLAP/2 && t2Pos > t1Pos) {
			Debug.Log ("Moving Background: tile2 down");
			t2Pos -= Y_MOVE;
			tile_2.transform.position = new Vector3(0, t2Pos, 0);
		}

	}
}

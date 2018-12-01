using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Leap_Frog : MonoBehaviour {

	public Transform tile_1, tile_2, camPosy; // position of tile
	public Vector3 offset; // starting position of each tile
	private const float Y_MOVE = 43.2f, OVERLAP = 23; // distance to move each tile
	private float t1Pos, t2Pos;

	void Start() {
		t1Pos = tile_1.position.y;
		t2Pos = tile_2.position.y;
		}
	
	// update the position of the background tiles in relation to the camera
	void Update () {

		// camera is above tile 1, player is in front of tile 2
		if (camPosy.transform.position.y > tile_1.transform.position.y + OVERLAP) {
			t1Pos += Y_MOVE;
			tile_1.transform.position = new Vector3(0, t1Pos, 0);
		}
		// camera is above tile 2, player is in front of tile 1
		else if (camPosy.transform.position.y > tile_2.transform.position.y + OVERLAP) {
			t2Pos += Y_MOVE;
			tile_2.transform.position = new Vector3(0, t2Pos, 0);
		}
		// camera is below tile 1, player is in front of tile 2
		else if (camPosy.transform.position.y < tile_1.transform.position.y - OVERLAP) {
			t1Pos -= Y_MOVE;
			tile_1.transform.position = new Vector3(0, t1Pos, 0);
		}
		// camera is below tile 2, plater is in front of tile 1
		else if (camPosy.transform.position.y < tile_2.transform.position.y - OVERLAP) {
			t2Pos -= Y_MOVE;
			tile_2.transform.position = new Vector3(0, t2Pos, 0);
		}
	}
}

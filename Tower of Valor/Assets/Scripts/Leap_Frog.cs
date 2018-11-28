using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Leap_Frog : MonoBehaviour {

	public Transform tile_1, tile_2, camPosy; // position of tile
	public Vector3 offset; // starting position of each tile
	private const float X_SCALE = 21.6f;
	private float t1Pos, t2Pos;

	// Use this for initialization
	void Start () {
		tile_1.transform.position = offset;
		tile_2.transform.position = new Vector3(0f, X_SCALE, 0f);
	}
	
	// update the position of the background tiles in relation to the camera
	void Update () {

		// camera is above tile 1, player is in front of tile 2
		if (camPosy.transform.position.y > tile_1.transform.position.y + X_SCALE) {
			t1Pos += (2 * X_SCALE);
			tile_1.transform.position = new Vector3(0, t1Pos, 0);
		}
		// camera is above tile 2, plater is in front of tile 1
		else if (camPosy.transform.position.y > tile_2.transform.position.y + X_SCALE) {
			t2Pos += (2 * X_SCALE);
			tile_2.transform.position = new Vector3(0, t2Pos, 0);
		}
		// camera is below tile 1, player is in front of tile 2
		else if (camPosy.transform.position.y < tile_1.transform.position.y - X_SCALE) {
			t1Pos -= (2 * X_SCALE);
			tile_1.transform.position = new Vector3(0, t1Pos, 0);
		}
		// camera is below tile 2, plater is in front of tile 1
		else if (camPosy.transform.position.y < tile_2.transform.position.y - X_SCALE) {
			t2Pos -= (2 * X_SCALE);
			tile_2.transform.position = new Vector3(0, t2Pos, 0);
		}
	}
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraScript : MonoBehaviour
{

    public Transform player1, player2;
    public Vector3 offset;  // initial camera position
    public float smoothTime; // time it takes for camera to reach target
    private Vector3 velocity = Vector3.zero;

	// Use this for initialization
	void Start ()
    {
        transform.position = offset;
	}
    void Update()
    {
        if (higherPlayer() > offset.y)
        {
            Vector3 camPosY = new Vector3(offset.x, higherPlayer(), offset.z);
            transform.position = Vector3.SmoothDamp(transform.position, camPosY, ref velocity, smoothTime);
        }
        else
        {
            transform.position = Vector3.SmoothDamp(transform.position, offset, ref velocity, smoothTime);
        }
    }
    public float higherPlayer()     // returns Y position of highest player.
    {
        if (player1.position.y >= player2.position.y)
        {
            return player1.position.y;
        }
        else
        {
            return player2.position.y;
        }
    }
}

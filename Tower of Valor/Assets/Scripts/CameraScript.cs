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

    void LateUpdate()
	{
		if (player1 == null && player2 == null)
		{
			Debug.Log ("GAMEOVER");
            FindObjectOfType<GameManager>().GameOver();
		}
		else
		{
			trackPlayer ();
		}
	}

    public float higherPlayer()     // returns Y position of highest player.
	{
		if (player1 == null)
		{
			return player2.position.y;
		}
		else if (player2 == null)
		{
			return player1.position.y;
		}
		else
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

	void trackPlayer()
	{
		if (higherPlayer () > offset.y)
		{
			Vector3 camPosY = new Vector3 (offset.x, higherPlayer (), offset.z);
			transform.position = Vector3.SmoothDamp (transform.position, camPosY, ref velocity, smoothTime);
		}
		else
		{
			transform.position = Vector3.SmoothDamp (transform.position, offset, ref velocity, smoothTime);
		}
	}

	public Transform SetPlayer1
	{
		set
		{
			player1 = value;
		}
	}

	public Transform SetPlayer2
	{
		set
		{ 
			player2 = value;
		}
	}
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class BelowCamera : MonoBehaviour 
{

	private Transform player1;
	private Transform player2;
	public float distance;
	private float distanceApart;
	AsyncOperation sceneCheck;
	// Use this for initialization

	void Start ()
	{
		player1 = Camera.main.GetComponent<CameraScript> ().player1;
		player2 = Camera.main.GetComponent<CameraScript> ().player2;
	}
	
	// Update is called once per frame
	void Update ()
	{
		CheckDistance ();
	}


	//concern is only the y coordinate value of the players since there will be walls on the sides of level
	void CheckDistance()
	{
		if (player1 == null || player2 == null)
		{
			//Debug.Log ("A player is dead");
			return;
		}
		else
		{
			distanceApart = Mathf.Abs (player1.position.y - player2.position.y);
			if (distanceApart > distance)
			{
				//find lower player, deal damage, then spawn on screen
				if (player1.position.y > player2.position.y)
				{
					player2.GetComponent<Health> ().removeHitPoints (2);
					if (player2.GetComponent<Health> ().player2Died)
					{
						return;
					}
					else
					{
						player2.GetComponent<Health> ().FindSpawn (player2.transform);
					}
				}
				if (player1.position.y < player2.position.y)
				{
					player1.GetComponent<Health> ().removeHitPoints (2);
					if (player1.GetComponent<Health> ().player1Died)
					{
						return;
					}
					else
					{
						player1.GetComponent<Health> ().FindSpawn (player1.transform);
					}
				}
			}
		}
	}
}


using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OffCamera : MonoBehaviour 
{
	void OnCollisionEnter2D(Collision2D collision)
	{
		GameObject entity = collision.gameObject;

		if (entity.tag == "Player")
		{
			entity.GetComponent<Health> ().removeHitPoints (2);
			FindObjectOfType<AudioManager>().Play("PlayerHit");

			if (entity.GetComponent<Health> ().player1Died || entity.GetComponent<Health> ().player2Died)
			{
				Debug.Log ("PlayerDied offscreen.");
				return;
			}
			else
			{
				entity.GetComponent<Health> ().FindSpawn (entity.transform);
			}
		}
	}
	

}

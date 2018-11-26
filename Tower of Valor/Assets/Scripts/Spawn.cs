using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawn : MonoBehaviour
{
	public GameObject[] entities;
	public float time;
	public WaitForSeconds spawnTime;

	// Use this for initialization
	void Start ()
	{
		spawnTime = new WaitForSeconds(time);
	}

	public void Respawn()
	{
		StartCoroutine(SpawnEntity());
	}

	public IEnumerator SpawnEntity()
	{
		for (int i = 0; i < entities.Length; ++i)
		{
			//spawns player1
			if (entities [i].GetComponent<Health> ().player1Died)
			{
				entities[i].transform.position = gameObject.transform.position;
				entities[i].SetActive(false);
				yield return spawnTime;
				entities[i].SetActive(true);
				entities [i].GetComponent<Health> ().player1Died = false;
			}
			//spawns player2 -> works if both players died at same time
			if (entities [i].GetComponent<Health> ().player2Died)
			{
				entities[i].transform.position = gameObject.transform.position;
				entities[i].SetActive(false);
				yield return spawnTime;
				entities[i].SetActive(true);
				entities [i].GetComponent<Health> ().player2Died = false;
			}
		}

	}
}

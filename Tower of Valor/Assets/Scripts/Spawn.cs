using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawn : MonoBehaviour
{
	public GameObject entity;
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
		entity.transform.position = gameObject.transform.position;

		entity.SetActive(false);

		yield return spawnTime;

		//Instantiate(entity, gameObject.transform.position, gameObject.transform.rotation);
		entity.SetActive(true);
	}
}

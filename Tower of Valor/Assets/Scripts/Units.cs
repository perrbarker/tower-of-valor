using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//This script contains the behaviours of the enemy units Gargoyle, Bat, Unknown, and BossWizard
public class Units : MonoBehaviour {

	private Rigidbody2D unit;
	public bool isGargoyle;
	public bool isBat;
	public bool isSpiritArmor;

	public float speed;
	public int attackRate;
	public float timeToDie;
	public float distance;
	private Vector3 position;
	private WaitForSeconds time;

	// Use this for initialization
	void Awake () 
	{
		unit = gameObject.GetComponent<Rigidbody2D>();
		Debug.Log ("awake");
		position = gameObject.transform.position;
		Patrol ();		
	}

	//This function will control the movement of enemy units
	void Patrol()
	{
		if (gameObject.GetComponent<Units> ().isBat || gameObject.GetComponent<Units> ().isSpiritArmor)
		{
			Debug.Log ("object is bat");
			unit.AddForce(transform.right * speed);
		}
		else
		{
			Debug.Log ("not bat");
		}
	}


}

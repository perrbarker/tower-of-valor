using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//This script contains the behaviours of the enemy units Gargoyle, Bat, Unknown, and BossWizard
public class Enemy : MonoBehaviour 
{

	//private Rigidbody2D unit;
	public bool isGargoyle;
	public bool isBat;
	public bool isSpiritArmor;

	public float speed;
	public float detect;

	private bool movingRight;
	public Transform groundDetection;
	private RaycastHit2D groundInfo;

	void Start()
	{
		if (gameObject.GetComponent<Enemy> ().isBat || gameObject.GetComponent<Enemy> ().isSpiritArmor)
		{
			movingRight = true;
			Debug.Log (speed);
		}
	}

	void Update()
	{
		//SPIRIT ARMOR
		if (gameObject.GetComponent<Enemy> ().isSpiritArmor)
		{
			groundInfo = Physics2D.Raycast (groundDetection.position, Vector2.down, detect);
			gameObject.transform.Translate (Vector2.right * speed * Time.deltaTime);

			if (groundInfo.collider == false)
			{
				if (movingRight == true)
				{
					transform.eulerAngles = new Vector3 (0, -180, 0);
					movingRight = false;
				}
				else
				{
					transform.eulerAngles = Vector3.zero;
					movingRight = true;
				}
			}
		}
		//BAT
		else if (gameObject.GetComponent<Enemy>().isBat)
		{
			gameObject.transform.Translate (Vector2.right * speed * Time.deltaTime);
			if (movingRight == true)
			{
				groundInfo = Physics2D.Raycast (groundDetection.position, Vector2.right, detect);
			}
			else
			{
				groundInfo = Physics2D.Raycast (groundDetection.position, Vector2.left, detect);
			}
			if (groundInfo.collider == true)
			{
				if (movingRight == true)
				{
					transform.eulerAngles = new Vector3 (0, -180, 0);
					movingRight = false;
					groundInfo = Physics2D.Raycast (groundDetection.position, Vector2.left, detect);
				}
				else
				{
					transform.eulerAngles = Vector3.zero;
					movingRight = true;
					groundInfo = Physics2D.Raycast (groundDetection.position, Vector2.right, detect);
				}
			}
		}
	}
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//This script contains the behaviours of the enemy units Gargoyle, Bat, Unknown, and BossWizard
public class Enemy : MonoBehaviour 
{

	public bool isGargoyle;
	public bool isBat;
	public bool isSpiritArmor;
	public Animator animator;

	public float speed;
	public float platformDetection;

	private bool movingRight;
	private float time;
	public Transform groundDetection;
	private RaycastHit2D groundInfo;

	void Start()
	{
		if (gameObject.GetComponent<Enemy> ().isBat || gameObject.GetComponent<Enemy> ().isSpiritArmor)
		{
			movingRight = true;
		}
		if (gameObject.GetComponent<Enemy> ().isGargoyle)
		{
			StartCoroutine (GargAttack ());
		}
	}

	void Update()
	{
		//SPIRIT ARMOR
		if (gameObject.GetComponent<Enemy> ().isSpiritArmor)
		{
			groundInfo = Physics2D.Raycast (groundDetection.position, Vector2.down, platformDetection);
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
			//move bat
			gameObject.transform.Translate (Vector2.right * speed * Time.deltaTime);

			if (movingRight == true)
			{
				//set LineOfSight to look right
				groundInfo = Physics2D.Raycast (groundDetection.position, Vector2.right, platformDetection);
			}
			else
			{
				//set lineOfSight to left
				groundInfo = Physics2D.Raycast (groundDetection.position, Vector2.left, platformDetection);
			}
			//check to not fly into platforms or other enemies, change direction otherwise
			if (groundInfo.collider == true && groundInfo.collider.gameObject.tag != "Player")
			{
				if (movingRight == true)
				{
					transform.eulerAngles = new Vector3 (0, -180, 0);
					movingRight = false;
					groundInfo = Physics2D.Raycast (groundDetection.position, Vector2.left, platformDetection);
				}
				else
				{
					transform.eulerAngles = Vector3.zero;
					movingRight = true;
					groundInfo = Physics2D.Raycast (groundDetection.position, Vector2.right, platformDetection);
				}
			}
		}
	}
		
	void OnCollisionExit2D(Collision2D collision)
	{
		GameObject collidedObject = collision.gameObject;

		//When leaving collision, if player, enable player health script
		if (collidedObject.tag == "Player")
		{
			Debug.Log (collidedObject);
			//if Gargoyle is being held, deal no damage
			if (gameObject.GetComponent<Throwable> ().isGrabbed)
			{
				Debug.Log ("Enemy is being held");
			}
			else
			{
				collidedObject.GetComponent<Health> ().removeHitPoints (1);
			}
		}
	}

	public IEnumerator GargAttack()
	{
		//choose random number
		float rng = Mathf.Round (Random.Range (0.0f, 1.0f));
		//attack left
		if(rng == 0.0)
		{
			animator.SetBool ("AttackLeft", true);
		}
		//attack right
		else
		{
			animator.SetBool("AttackRight", true);
		}

		yield return new WaitForSeconds (2.0f);
		StartCoroutine (GargAttack ());
	}

	public void StopAnimation(string animationParameter)
	{
		animator.SetBool(animationParameter, false);
	}
}
using System.Collections;
using UnityEngine;

public class Health : MonoBehaviour {

    public int maxHP;
    public int hitPoints;
	public int lives;
    public float timeToDestroy;
	public GameObject spawn;

    void Start()
    {
        hitPoints = maxHP;
    }

    void LateUpdate()
    {
        if (hitPoints <= 0)
        {
            StartCoroutine(Death());
        }
    }

    public int HitPoints
    {
        get { return hitPoints; }
		set
		{
			hitPoints += value;
			if (hitPoints > maxHP)
			{
				hitPoints = maxHP;
			}
		}

    }

    public void removeHitPoints(int i)
    {
        hitPoints -= i;
		Debug.Log(gameObject.tag + "'s HP is at " + gameObject.GetComponent<Health>().HitPoints);
    }

    IEnumerator Death()
    {
        yield return new WaitForSeconds(timeToDestroy);

		if (gameObject.tag == "Player")
		{
			hitPoints = maxHP;
			--lives;
			if (lives < 0)
			{
				Destroy (gameObject);

				if (gameObject.transform == Camera.main.GetComponent<CameraScript> ().player1)
				{
					Camera.main.GetComponent<CameraScript> ().SetPlayer1 = Camera.main.GetComponent<CameraScript> ().player2;

				}
				else if (gameObject.transform == Camera.main.GetComponent<CameraScript> ().player2)
				{
					Camera.main.GetComponent<CameraScript> ().SetPlayer2 = Camera.main.GetComponent<CameraScript> ().player1;
				}
			}
			else
			{
				Spawn respawn = spawn.GetComponent<Spawn> ();
				respawn.Respawn ();
			}
		}
		else
		{
            Destroy(gameObject);
		}
    }

	public GameObject Spawn
	{
		get { return spawn; }
		set
		{
			spawn = value;
		}
	}
}

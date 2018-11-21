using System.Collections;
using UnityEngine;

public class Health : MonoBehaviour {

    public int maxHP;
    public int hitPoints;
    public float timeToDestroy;
<<<<<<< HEAD
	private GameObject spawn;
	public GameObject[] spawnPoints;
	private float distanceFromPlayer;
	private int closestSpawn;
	private float tmpDistance;
	private float tmpX;
	private float tmpY;
=======
>>>>>>> parent of 40e6891... Merge remote-tracking branch 'origin/master'

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

    }

    public void removeHitPoints(int i)
    {
        hitPoints -= i;
		Debug.Log(gameObject.tag + "'s is at " + gameObject.GetComponent<Health>().HitPoints);
    }

    IEnumerator Death()
    {
        yield return new WaitForSeconds(timeToDestroy);
		if (gameObject.transform == Camera.main.GetComponent<CameraScript> ().player1)
		{
			Camera.main.GetComponent<CameraScript> ().SetPlayer1 = Camera.main.GetComponent<CameraScript> ().player2;

<<<<<<< HEAD
				}
				else if (gameObject.transform == Camera.main.GetComponent<CameraScript> ().player2)
				{
					Camera.main.GetComponent<CameraScript> ().SetPlayer2 = Camera.main.GetComponent<CameraScript> ().player1;
				}
			}
			else
			{
				//SPAWNS BASED ON THE POSITION OF THE PLAYER, WILL FIND CLOSEST SPAWN POINT FROM DEATH
				//NEEDS TO BE MODIFYIED TO BASE SPAWN POINT ON PLAYER 2 POSITION
				//SPAWNER NEEDS TO SPAWN EITHER PLAYER 1 OR PLAYER 2 NOT JUST GAMEOBJECT GIVEN

				tmpX = Mathf.Abs (gameObject.transform.position.x - spawnPoints [0].transform.position.x);
				tmpY = Mathf.Abs (gameObject.transform.position.y - spawnPoints [0].transform.position.y);
				tmpDistance = Mathf.Sqrt (Mathf.Pow (tmpX, 2) + Mathf.Pow (tmpY, 2));
				distanceFromPlayer = tmpDistance;
				closestSpawn = 0;

				for (int i = 1; i < spawnPoints.Length; ++i)
				{
					tmpX = Mathf.Abs (gameObject.transform.position.x - spawnPoints [i].transform.position.x);
					tmpY = Mathf.Abs (gameObject.transform.position.y - spawnPoints [i].transform.position.y);
					tmpDistance = Mathf.Sqrt (Mathf.Pow (tmpX, 2) + Mathf.Pow (tmpY, 2));

					if (tmpDistance < distanceFromPlayer)
					{
						distanceFromPlayer = tmpDistance;
						closestSpawn = i;
					}
				}
				Spawn respawn = spawnPoints[closestSpawn].GetComponent<Spawn> ();
				respawn.Respawn ();
			}
=======
>>>>>>> parent of 40e6891... Merge remote-tracking branch 'origin/master'
		}
		else if (gameObject.transform == Camera.main.GetComponent<CameraScript> ().player2)
		{
<<<<<<< HEAD
<<<<<<< HEAD
			Destroy (gameObject);
=======
            Destroy(gameObject);
>>>>>>> 40e689189b36576ef9fdefa635b8d6dcf609b91f
=======
			Camera.main.GetComponent<CameraScript> ().SetPlayer2 = Camera.main.GetComponent<CameraScript> ().player1;
>>>>>>> parent of 40e6891... Merge remote-tracking branch 'origin/master'
		}
		Destroy (gameObject);
    }
}

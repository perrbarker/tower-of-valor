using System.Collections;
using UnityEngine;

public class Health : MonoBehaviour {

    public int maxHP;
    public int hitPoints;
    public float timeToDestroy;

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
    }

    IEnumerator Death()
    {
        yield return new WaitForSeconds(timeToDestroy);
		if (gameObject.transform == null)
		{
			Debug.Log ("GAME OBJECT IS NULL");
		}
		else
		{
			Destroy (gameObject);
		}
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fireball : MonoBehaviour {

    public float speed;
    public float lifeTime;
    public int damage;
    private Vector2 targetDir;

	// Use this for initialization
	void Start () 
	{
        Invoke("DestroyProjectile", lifeTime);
        FindObjectOfType<AudioManager>().Play("FireballCast");
	}
	
    public void SetTargetDirection(Vector2 dir)
    {
        targetDir = dir;
    }

	// Update is called once per frame
	void Update () {

        transform.position += (Vector3) targetDir * speed* Time.deltaTime;
    }


    void OnTriggerEnter2D(Collider2D collision)
    {
        Transform obj = collision.GetComponent<Transform>();

        if (obj != null)
        {
            if (obj.tag == "Player")
            {
                // hit body
                if (obj.name == "P1_Head")
                {
                    print("Hit head");
                    obj.GetComponentInParent<Health>().removeHitPoints(damage);
                    Destroy(gameObject);
                }


            }
            /*
            if (collision.GetComponent<Transform>().tag == "Platform")
            {
                Destroy(gameObject);
            }
            */
        }
    }

    void DestroyProjectile()
    {
        Destroy(gameObject);
    }
}

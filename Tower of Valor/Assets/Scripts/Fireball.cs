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
        if (collision.GetComponent<Transform>().tag == "Player")
        {
            print("Hit player");
            collision.GetComponent<Health>().removeHitPoints(damage);
            Destroy(gameObject);
        }
        if (collision.GetComponent<Transform>().tag == "Platform")
        {
            Destroy(gameObject);
        }


    }

    void DestroyProjectile()
    {
        Destroy(gameObject);
    }
}

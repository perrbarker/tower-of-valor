using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wizard : MonoBehaviour {

    public Transform p1, p2;
    private float dist1, dist2;
    private int health1, health2;

    public Animator anim;
    public float aggroDistance;
    public float attackCoolDown;
    private float timer;
    public GameObject projectile;


    private void Start()
    {
        anim = GetComponent<Animator>();
        timer = attackCoolDown;
    }
    // Update is called once per frame
    void Update () {

        timer += Time.deltaTime;

        if (p1 != null)
        {
            dist1 = (Vector2.Distance(p1.position, transform.position));
            health1 = p1.GetComponent<Health>().hitPoints;
        }
        if (p2 != null)
        {
            dist2 = (Vector2.Distance(p2.position, transform.position));
            health2 = p2.GetComponent<Health>().hitPoints;
        }


        if (timer > attackCoolDown)
        {
            // at least 1 player in aggroDistance
            if (((dist1 <= aggroDistance) && (p1 != null)) || ((dist2 <= aggroDistance) && (p2 != null)))
            { 
                // both in aggroDistance
                if (((dist1 <= aggroDistance) && (p1 != null)) && ((dist1 <= aggroDistance) && (p2 != null)))
                {

                    switch(Random.Range(1,4))
                    {
                        // fire at p1
                        case 1:
                            anim.SetBool("isAttack", true);
                            StartCoroutine(SpawnFireball(p1));
                            timer = 0;
                            break;
                        // fire at p2
                        case 2:
                            anim.SetBool("isAttack", true);
                            StartCoroutine(SpawnFireball(p2));
                            timer = 0;
                            break;
                        // fire at both
                        case 3:
                            anim.SetBool("isAttack", true);
                            StartCoroutine(SpawnFireball(p1));
                            StartCoroutine(SpawnFireball(p2));
                            timer = 0;
                            break;
                    }
                }
                
                // only 1 in aggroDistance
                // p1
                else if ((dist1 <= aggroDistance) && (p1 != null))
                {
                    anim.SetBool("isAttack", true);
                    StartCoroutine(SpawnFireball(p1));
                    timer = 0;
                }
                // p2
                else if ((dist2 <= aggroDistance) && (p2 != null))
                {
                    anim.SetBool("isAttack", true);
                    StartCoroutine(SpawnFireball(p2));
                    timer = 0;
                }
            }
        }   

    }


    IEnumerator SpawnFireball(Transform target)
    {
        yield return new WaitForSeconds(1f);
        anim.SetBool("isAttack", false);
        GameObject projectileInstance;

        if (target != null)
        {
            projectileInstance = Instantiate(projectile, transform.position, transform.rotation);
            Vector2 dir = (target.position - transform.position).normalized;

            projectileInstance.GetComponent<Fireball>().SetTargetDirection(dir);
        }

    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wizard : MonoBehaviour {

    public Transform p1, p2;
    private float dist1, dist2;
    private int health1, health2;

    private bool activeWizard;

    public Animator anim;
    public float aggroDistance;
    public float attackCoolDown;
    private float timer;
    private int health;

    public GameObject projectile;
    private bool enraged;

    public Transform[] teleportPos;
    private int lastPos;

    private void Start()
    {
        anim = GetComponent<Animator>();
        timer = attackCoolDown;
        activeWizard = false;
    }
    // Update is called once per frame
    void Update () {


        health = GetComponent<Health>().hitPoints;
        timer += Time.deltaTime;

        if (p1 != null)
        {
            dist1 = (Vector2.Distance(p1.position, transform.position));
            health1 = p1.GetComponent<Health>().hitPoints;
            if (dist1 <= aggroDistance)
            {
                activeWizard = true;
            }
        }
        if (p2 != null)
        {
            dist2 = (Vector2.Distance(p2.position, transform.position));
            health2 = p2.GetComponent<Health>().hitPoints;
            if (dist2 <= aggroDistance)
            {
                activeWizard = true;
            }
        }

        if (health < 3)
        {
            enraged = true;
        }

        if (activeWizard)
        {
            if (timer > attackCoolDown)
            {
                SelectTarget();
            }
        }
    }

    void LevitateDown()
    {

    }

    void SelectTarget()
    {
        // at least 1 player in aggroDistance
        if (((dist1 <= aggroDistance) && (p1 != null)) || ((dist2 <= aggroDistance) && (p2 != null)))
        {
            // both in aggroDistance
            if (((dist1 <= aggroDistance) && (p1 != null)) && ((dist1 <= aggroDistance) && (p2 != null)))
            {

                switch (Random.Range(1, 4))
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

    void FireballAOE()
    {
        anim.SetBool("isAttack", true);

        GameObject[] projectileInstances = new GameObject[8];
        Vector2[] directions = new Vector2[8];


        directions[0] = Vector2.up;
        directions[1] = Vector2.down;
        directions[2] = Vector2.left;
        directions[3] = Vector2.right;
        directions[4] = Vector2.up + Vector2.left;
        directions[5] = Vector2.up + Vector2.right;
        directions[6] = Vector2.down + Vector2.left;
        directions[7] = Vector2.down + Vector2.right;


        // Instantiate projectile
        for (int i = 0; i < 8; i++)
        {
            projectileInstances[i] = Instantiate(projectile, transform.position, transform.rotation);
            projectileInstances[i].GetComponent<Fireball>().SetTargetDirection(directions[i]);
        }
    }

    public void Teleport()
    {
        switch (Random.Range(0,2))
        {
            case 0:
                    transform.position = teleportPos[0].position;
                    lastPos = 0;
                break;
            case 1:
                    transform.position = teleportPos[1].position;
                    lastPos = 1;
                break;
        }


        if (enraged)
        {
            Invoke("FireballAOE", 1.5f);
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

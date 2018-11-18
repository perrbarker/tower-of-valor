using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Punch : MonoBehaviour {

    public KeyCode punch;
    public float punchRange;
    public float pushBackForce;
    public bool facingLeft;

    private Vector3 vecDir;
    private Vector2 vecSide;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(punch))
        {
            CheckDirFacing();

            // Set which direction to cast ray
            if (facingLeft)
            {
                vecSide = transform.position + new Vector3(-.65f, 0f, 0f);
                vecDir = Vector2.left;
            }
            else
            {
                vecSide = transform.position + new Vector3(.65f, 0f, 0f);
                vecDir = Vector2.right;
            }


            Debug.DrawRay(vecSide, vecDir * punchRange);

            RaycastHit2D hitPunch = Physics2D.Raycast(vecSide, vecDir, punchRange);

            if (hitPunch == true)
            {

                // Pushback?
                hitPunch.transform.GetComponent<Rigidbody2D>().AddForce(vecSide * pushBackForce);

                // Damages SpiritArmor
                if (hitPunch.transform.tag == "SpiritArmor")
                {
                    hitPunch.transform.GetComponent<Health>().removeHitPoints(3);
                }

                
            }


        }
    }

    void CheckDirFacing()
    {
        facingLeft = GetComponent<playerMovement>().movingLeft; // set direction facing
    }
}

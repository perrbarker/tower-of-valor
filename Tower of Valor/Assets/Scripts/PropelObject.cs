using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PropelObject : MonoBehaviour {

    public Transform[] topPoints;
    public float bounce;
    public float range;
    public bool touchedTop;

    void OnCollisionEnter2D(Collision2D collision)
    {
        // check if top colliders is touched
        checkRayCastHit();
        if (touchedTop)
        {
            collision.rigidbody.velocity = new Vector2(0, bounce);

        }

    }

    void checkRayCastHit()
    {
        RaycastHit2D hit0 = Physics2D.Raycast(topPoints[0].position, Vector2.up, range);
        RaycastHit2D hit1 = Physics2D.Raycast(topPoints[1].position, Vector2.up, range);
        RaycastHit2D hit2 = Physics2D.Raycast(topPoints[2].position, Vector2.up, range);

        if (hit0 == true || hit1 == true || hit2 == true)
        {
            Debug.Log("Hit something on top");
            touchedTop = true;
        }
        else
        {
            touchedTop = false;
        }
        
    }

}

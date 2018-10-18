using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Throwable : MonoBehaviour {

    public bool isGrabbed;
    public bool isThrown;


    void Update () {

        if (isGrabbed)
        {
            DisableMovement();
        }
	}

    // disable movement script
    void DisableMovement()
    {
        gameObject.GetComponent<playerMovement>().enabled = false;  
    }

    // Object regains movement if collided with something after being thrown
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (isThrown)
        {
            GetComponent<playerMovement>().enabled = true;   // enable movement script
            isThrown = false;
        }

    }
}

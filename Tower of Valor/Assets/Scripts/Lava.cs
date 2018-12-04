using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lava : MonoBehaviour {

    [Range(0,10)]
    public float riseSpeed;
    public float triggerHeight;
    public float maxHeight;
    public bool lavaIsActive = false;
	public float headStart;

    private readonly float offset = -7f; // distance from top of lava to its pivot point (center)


    public Transform player1, player2;

	// Use this for initialization
	void Start() 
	{
		//FindObjectOfType<AudioManager>().Play("LavaRising");
		//FindObjectOfType<AudioManager>().Play("FireBurning");

		//FindObjectOfType<AudioManager>().Mute("LavaRising");
		//FindObjectOfType<AudioManager>().Mute("FireBurning");
		lavaIsActive = false;
	}
	
	// Update is called once per frame
	void Update () {

        float lavaHeight = transform.position.y;

        // activate lava rise if one of the players reached trigger height
		if (!lavaIsActive)
        {
            if (player1 != null)
            {
                if (player1.position.y >= triggerHeight)
                {
					lavaIsActive = true;
                    //print("lava activated");
					transform.position = new Vector2 (0.0f, player1.position.y - headStart);
                }
            }

            if (player2 != null)
            {
                if (player2.position.y >= triggerHeight)
                {
					lavaIsActive = true;
                    //print("lava activated");
					transform.position = new Vector2 (0.0f, player2.position.y - headStart);
                }
            }
        }

		if (lavaIsActive)
        {
            RiseLava();
            if (lavaHeight >= maxHeight + offset)
            {
                //print("Reached max height");
                riseSpeed = 0;
            }
        }

	}

    private void OnTriggerEnter2D(Collider2D collision)
    {
        // if object has health script, deal massive damage to it
        if (collision.GetComponent<Health>() != null)
        {
            //print("Touched player");
            collision.GetComponent<Health>().removeHitPoints(3);
        }
    }

    void RiseLava()
    {
		FindObjectOfType<AudioManager> ().Mute("Theme");
		FindObjectOfType<AudioManager>().UnMute("LavaRising");
		FindObjectOfType<AudioManager>().UnMute("FireBurning");
		transform.position = transform.position + new Vector3(0f, riseSpeed * Time.deltaTime);
    }
}

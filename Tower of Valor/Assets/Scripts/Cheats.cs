using UnityEngine;

public class Cheats : MonoBehaviour {

    public Transform p1;
    public KeyCode teleport;
    public Transform telPosition;

	
	// Update is called once per frame
	void Update () {

        if (Input.GetKeyDown(teleport))
        {
            p1.position = telPosition.position;
        }

    }
}

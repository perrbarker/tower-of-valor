using UnityEngine;

public class Cheats : MonoBehaviour {

    public Transform p1, p2;
    public KeyCode teleport;
    public Transform telPosition1;
    public Transform telPosition2;



    // Update is called once per frame
    void Update () {

        if (Input.GetKeyDown(teleport))
        {
            if (p1 != null)
            {
                p1.position = telPosition1.position;
            }
            if (p2 != null)
            {
                p2.position = telPosition2.position;

            }
        }

    }
}

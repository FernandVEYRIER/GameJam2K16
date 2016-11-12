using UnityEngine;
using System.Collections;

public class HandleGui : MonoBehaviour {

    public RotateMap map;
	// Update is called once per frame
	void Update ()
    {
        if (Input.GetAxis("Horizontal") < 0)
            map.rotate(RotateMap.State.right);
        else if (Input.GetAxis("Horizontal") > 0)
            map.rotate(RotateMap.State.left);
    }
}

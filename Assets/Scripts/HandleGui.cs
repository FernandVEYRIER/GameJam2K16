using UnityEngine;
using System.Collections;

public class HandleGui : MonoBehaviour {

    public RotateMap map;
	// Update is called once per frame
	void Update ()
    {
		if (Input.GetAxis("P0LeftHorizontal") < 0)
            map.rotate(RotateMap.State.left);
		else if (Input.GetAxis("P0LeftHorizontal") > 0)
            map.rotate(RotateMap.State.right);
    }
}


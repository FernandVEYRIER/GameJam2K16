using UnityEngine;
using System.Collections;

public class HandleGui : MonoBehaviour {

    public RotateMap map;
    private bool isrotate = false;
	// Update is called once per frame
	void Update ()
    {
        //if (!isrotate && Input.GetAxis("P0LeftHorizontal") < 0)
        //{
        //    map.rotate(RotateMap.State.right);
        //    isrotate = true;
        //}
        //else if (!isrotate && Input.GetAxis("P0LeftHorizontal") > 0)
        //{
        //    map.rotate(RotateMap.State.left);
        //    isrotate = true;
        //}
        //else if (Input.GetAxis("P0LeftHorizontal") == 0)
        //    isrotate = false;
    }
}


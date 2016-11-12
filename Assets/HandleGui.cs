using UnityEngine;
using System.Collections;

public class HandleGui : MonoBehaviour {

    public RotateMap map;
    private bool can_rotate = true;
	// Update is called once per frame
	void Update ()
    {
        if (Input.GetAxis("Horizontal") < 0)
            map.rotate(RotateMap.State.right);
        else if (Input.GetAxis("Horizontal") > 0)
            map.rotate(RotateMap.State.left);
        else if (Input.GetAxis("Vertical") < 0)
            map.rotate(RotateMap.State.right180);
        else if (Input.GetAxis("Vertical") > 0)
            map.rotate(RotateMap.State.left180);
    }

    IEnumerator handle_right()
    {
        can_rotate = false;
        yield return new WaitForSeconds(0.3f);
        map.rotate(RotateMap.State.right);
        can_rotate = true;
    }

    IEnumerator handle_left()
    {
        can_rotate = false;
        yield return new WaitForSeconds(0.3f);
        map.rotate(RotateMap.State.left);
        can_rotate = true;
    }
}

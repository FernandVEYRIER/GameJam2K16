using UnityEngine;
using System.Collections;

public class GamepadInput : MonoBehaviour {

    [SerializeField]
	PlayerController playerCharacter;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        var index = playerCharacter.PlayerIndex;

        /////////////////////// AXES ////////////////////////////////
	    if(Input.GetAxis("P" + index + "LeftHorizontal") > 0)
        {
            //TODO
        }
        else if (Input.GetAxis("P" + index + "LeftHorizontal") < 0)
        {
            //TODO
        }

        if (Input.GetAxis("P" + index + "LeftVertical") > 0)
        {
            //TODO
        }
        else if (Input.GetAxis("P" + index + "LeftVertical") < 0)
        {
            //TODO
        }

        if (Input.GetAxis("P" + index + "RightHorizontal") > 0)
        {
            //TODO
        }
        else if (Input.GetAxis("P" + index + "RightHorizontal") < 0)
        {
            //TODO
        }

        if (Input.GetAxis("P" + index + "RightVertical") > 0)
        {
            //TODO
        }
        else if (Input.GetAxis("P" + index + "RightVertical") < 0)
        {
            //TODO
        }

        //////////////////////// BUTTONS ///////////////////////////////

        if (Input.GetButtonDown("P" + index + "ButtonA"))
        {
            Debug.Log("P" + index + "ButtonA Hello!");
            playerCharacter.UsePowerUp(Assets.Scripts.Direction.DOWN);
        }
        if (Input.GetButtonDown("P" + index + "ButtonB"))
        {
            Debug.Log("P" + index + "ButtonB Hello!");
            playerCharacter.UsePowerUp(Assets.Scripts.Direction.RIGHT);
        }
        if (Input.GetButtonDown("P" + index + "ButtonX"))
        {
            playerCharacter.UsePowerUp(Assets.Scripts.Direction.LEFT);
        }
        if (Input.GetButtonDown("P" + index + "ButtonY"))
        {
            playerCharacter.UsePowerUp(Assets.Scripts.Direction.TOP);
        }
    }
}

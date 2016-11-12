using UnityEngine;
using System.Collections;

public class GamepadInput : MonoBehaviour {

    [SerializeField]
    PlayerCharacter playerCharacter;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

        /////////////////////// AXES ////////////////////////////////
	    if(Input.GetAxis("P" + playerCharacter.PlayerIndex + "LeftHorizontal") > 0)
        {
            //TODO
        }
        else if (Input.GetAxis("P" + playerCharacter.PlayerIndex + "LeftHorizontal") < 0)
        {
            //TODO
        }

        if (Input.GetAxis("P" + playerCharacter.PlayerIndex + "LeftVertical") > 0)
        {
            //TODO
        }
        else if (Input.GetAxis("P" + playerCharacter.PlayerIndex + "LeftVertical") < 0)
        {
            //TODO
        }

        if (Input.GetAxis("P" + playerCharacter.PlayerIndex + "RightHorizontal") > 0)
        {
            //TODO
        }
        else if (Input.GetAxis("P" + playerCharacter.PlayerIndex + "RightHorizontal") < 0)
        {
            //TODO
        }

        if (Input.GetAxis("P" + playerCharacter.PlayerIndex + "RightVertical") > 0)
        {
            //TODO
        }
        else if (Input.GetAxis("P" + playerCharacter.PlayerIndex + "RightVertical") < 0)
        {
            //TODO
        }

        //////////////////////// BUTTONS ///////////////////////////////

        if (Input.GetButtonDown("P" + playerCharacter.PlayerIndex + "ButtonA"))
        {
            //TODO
        }
        if (Input.GetButtonDown("P" + playerCharacter.PlayerIndex + "ButtonB"))
        {
            //TODO
        }
        if (Input.GetButtonDown("P" + playerCharacter.PlayerIndex + "ButtonX"))
        {
            //TODO
        }
        if (Input.GetButtonDown("P" + playerCharacter.PlayerIndex + "ButtonY"))
        {
            //TODO
        }
    }
}

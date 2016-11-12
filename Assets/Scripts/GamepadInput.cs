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
	    if(Input.GetAxis("P" + playerCharacter.playerIndex + 1 + "LeftHorizontal") > 0)
        {
            //TODO
        }
        else if (Input.GetAxis("P" + playerCharacter.playerIndex + 1 + "LeftHorizontal") < 0)
        {
            //TODO
        }

        if (Input.GetAxis("P" + playerCharacter.playerIndex + 1 + "LeftVertical") > 0)
        {
            //TODO
        }
        else if (Input.GetAxis("P" + playerCharacter.playerIndex + 1 + "LeftVertical") < 0)
        {
            //TODO
        }

        if (Input.GetAxis("P" + playerCharacter.playerIndex + 1 + "RightHorizontal") > 0)
        {
            //TODO
        }
        else if (Input.GetAxis("P" + playerCharacter.playerIndex + 1 + "RightHorizontal") < 0)
        {
            //TODO
        }

        if (Input.GetAxis("P" + playerCharacter.playerIndex + 1 + "RightVertical") > 0)
        {
            //TODO
        }
        else if (Input.GetAxis("P" + playerCharacter.playerIndex + 1 + "RightVertical") < 0)
        {
            //TODO
        }

        //////////////////////// BUTTONS ///////////////////////////////

        if (Input.GetButtonDown("P" + playerCharacter.playerIndex + 1 + "ButtonA"))
        {
            //TODO
        }
        if (Input.GetButtonDown("P" + playerCharacter.playerIndex + 1 + "ButtonB"))
        {
            //TODO
        }
        if (Input.GetButtonDown("P" + playerCharacter.playerIndex + 1 + "ButtonX"))
        {
            //TODO
        }
        if (Input.GetButtonDown("P" + playerCharacter.playerIndex + 1 + "ButtonY"))
        {
            //TODO
        }
    }
}

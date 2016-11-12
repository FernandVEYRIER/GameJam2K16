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
	    if(Input.GetAxis("P" + playerCharacter.playerIndex + "LeftHorizontal") > 0)
        {
            //TODO
        }
        else if (Input.GetAxis("P" + playerCharacter.playerIndex + "LeftHorizontal") < 0)
        {
            //TODO
        }

        if (Input.GetAxis("P" + playerCharacter.playerIndex + "LeftVertical") > 0)
        {
            //TODO
        }
        else if (Input.GetAxis("P" + playerCharacter.playerIndex + "LeftVertical") < 0)
        {
            //TODO
        }

        if (Input.GetAxis("P" + playerCharacter.playerIndex + "RightHorizontal") > 0)
        {
            //TODO
        }
        else if (Input.GetAxis("P" + playerCharacter.playerIndex + "RightHorizontal") < 0)
        {
            //TODO
        }

        if (Input.GetAxis("P" + playerCharacter.playerIndex + "RightVertical") > 0)
        {
            //TODO
        }
        else if (Input.GetAxis("P" + playerCharacter.playerIndex + "RightVertical") < 0)
        {
            //TODO
        }

        //////////////////////// BUTTONS ///////////////////////////////

        if (Input.GetButtonDown("P" + playerCharacter.playerIndex + "ButtonA"))
        {
            //TODO
        }
        if (Input.GetButtonDown("P" + playerCharacter.playerIndex + "ButtonB"))
        {
            //TODO
        }
        if (Input.GetButtonDown("P" + playerCharacter.playerIndex + "ButtonX"))
        {
            //TODO
        }
        if (Input.GetButtonDown("P" + playerCharacter.playerIndex + "ButtonY"))
        {
            //TODO
        }
    }
}

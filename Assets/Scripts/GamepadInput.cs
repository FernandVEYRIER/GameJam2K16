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
            playerCharacter.UsePowerUp(Assets.Scripts.Direction.DOWN);
        }
        if (Input.GetButtonDown("P" + playerCharacter.PlayerIndex + "ButtonB"))
        {
            playerCharacter.UsePowerUp(Assets.Scripts.Direction.RIGHT);
        }
        if (Input.GetButtonDown("P" + playerCharacter.PlayerIndex + "ButtonX"))
        {
            playerCharacter.UsePowerUp(Assets.Scripts.Direction.LEFT);
        }
        if (Input.GetButtonDown("P" + playerCharacter.PlayerIndex + "ButtonY"))
        {
            playerCharacter.UsePowerUp(Assets.Scripts.Direction.TOP);
        }
    }
}

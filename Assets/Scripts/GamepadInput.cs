﻿using UnityEngine;
using System.Collections;
using Assets.Scripts;

public class GamepadInput : MonoBehaviour {

    [SerializeField]
	PlayerController playerCharacter;

	// Use this for initialization
	void Start () {
	
	}

    // Update is called once per frame
    void Update()
    {
        var index = playerCharacter.PlayerIndex;

		if (Input.GetKeyDown(KeyCode.Space))
		{
			Debug.Log ("Get input space. Grounded ? " + playerCharacter.Grounded);
            if (playerCharacter.Grounded)
            {
                playerCharacter.Grounded = false;
                GetComponent<Rigidbody2D>().AddForce(transform.up * 4500f);
            }
		}
        /////////////////////// AXES ////////////////////////////////
        if (Input.GetAxis("P" + index + "LeftHorizontal") > 0.4)
        {
            jump("Right");
        }
        else if (Input.GetAxis("P" + index + "LeftHorizontal") < -0.4)
        {
            jump("Left");
        }

        if (Input.GetAxis("P" + index + "LeftVertical") > 0.4)
        {
            Debug.Log("current index:" + index);
            jump("Up");
        }
        else if (Input.GetAxis("P" + index + "LeftVertical") < -0.4)
        {
            jump("Down");
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

			if (GameManager.GM.State == GameState.END)
				GameManager.GM.LoadLevel (0);
        }
        if (Input.GetButtonDown("P" + index + "ButtonB"))
        {
            Debug.Log("P" + index + "ButtonB Hello!");
            playerCharacter.UsePowerUp(Assets.Scripts.Direction.RIGHT);

			if (GameManager.GM.State == GameState.END)
				GameManager.GM.LoadLevel (0);
        }
        if (Input.GetButtonDown("P" + index + "ButtonX"))
        {
            playerCharacter.UsePowerUp(Assets.Scripts.Direction.LEFT);

			if (GameManager.GM.State == GameState.END)
				GameManager.GM.LoadLevel (0);
        }
        if (Input.GetButtonDown("P" + index + "ButtonY"))
        {
            playerCharacter.UsePowerUp(Assets.Scripts.Direction.TOP);

			if (GameManager.GM.State == GameState.END)
				GameManager.GM.LoadLevel (0);
        }
        if (Input.GetButtonDown("P" + index + "ButtonPause"))
        {
            Debug.Log("GamePause");
			if (GameManager.GM.State == GameState.PAUSE || GameManager.GM.State == GameState.PLAY)
            	GameManager.GM.SetPause();
        }
    }

    void jump(string dir)
    {
        if (playerCharacter.Grounded)
        {
            if (playerCharacter.Moves[0] == dir)
            {
                playerCharacter.Grounded = false;
                playerCharacter.GetComponent<Rigidbody2D>().AddForce(transform.up * 4500f);
            }
            else
            {
                //TODO: feedback wrong input 
            }
        }
    }
}

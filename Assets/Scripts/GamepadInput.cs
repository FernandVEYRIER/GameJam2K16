using UnityEngine;
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

//		if (Input.GetKeyDown(KeyCode.Space))
//		{
//            if (playerCharacter.Grounded)
//            {
//                playerCharacter.Grounded = false;
//                GetComponent<Rigidbody2D>().AddForce(transform.up * 4500f);
//            }
//		}
        /////////////////////// AXES ////////////////////////////////
        if (Input.GetAxis("P" + index + "LeftHorizontal") > 0.4)
        {
			if (GameManager.GM.State == GameState.PLAY)
            	jump("Right");
        }
        else if (Input.GetAxis("P" + index + "LeftHorizontal") < -0.4)
        {
			if (GameManager.GM.State == GameState.PLAY)
            	jump("Left");
        }

        if (Input.GetAxis("P" + index + "LeftVertical") > 0.4)
        {
            Debug.Log("current index:" + index);
			if (GameManager.GM.State == GameState.PLAY)
            	jump("Up");
        }
        else if (Input.GetAxis("P" + index + "LeftVertical") < -0.4)
        {
			if (GameManager.GM.State == GameState.PLAY)
            	jump("Down");
        }

//        if (Input.GetAxis("P" + index + "RightHorizontal") > 0)
//        {
//            //TODO
//        }
//        else if (Input.GetAxis("P" + index + "RightHorizontal") < 0)
//        {
//            //TODO
//        }
//
//        if (Input.GetAxis("P" + index + "RightVertical") > 0)
//        {
//            //TODO
//        }
//        else if (Input.GetAxis("P" + index + "RightVertical") < 0)
//        {
//            //TODO
//        }

        //////////////////////// BUTTONS ///////////////////////////////

        if (Input.GetButtonDown("P" + index + "ButtonA"))
        {
            Debug.Log("P" + index + "ButtonA Hello!");
			if (GameManager.GM.State == GameState.PLAY)
            	playerCharacter.UsePowerUp(Assets.Scripts.Direction.DOWN);
        }
        if (Input.GetButtonDown("P" + index + "ButtonB"))
        {
            Debug.Log("P" + index + "ButtonB Hello!");
			if (GameManager.GM.State == GameState.PLAY)
            	playerCharacter.UsePowerUp(Assets.Scripts.Direction.RIGHT);
        }
        if (Input.GetButtonDown("P" + index + "ButtonX"))
        {
			if (GameManager.GM.State == GameState.PLAY)
            	playerCharacter.UsePowerUp(Assets.Scripts.Direction.LEFT);
        }
        if (Input.GetButtonDown("P" + index + "ButtonY"))
        {
			if (GameManager.GM.State == GameState.PLAY)
            	playerCharacter.UsePowerUp(Assets.Scripts.Direction.TOP);
        }
        if (Input.GetButtonDown("P" + index + "ButtonPause"))
        {
			if (GameManager.GM.State == GameState.PAUSE || GameManager.GM.State == GameState.PLAY)
            	GameManager.GM.SetPause();
			if (GameManager.GM.State == GameState.END)
				GameManager.GM.LoadLevel (0);
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

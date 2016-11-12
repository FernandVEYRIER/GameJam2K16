using UnityEngine;
using System.Collections;
using Assets.Scripts;

public class GameManager : AGameManager {

	[Header("GUI")]
	[SerializeField] private GameObject canvasPause;
	[SerializeField] private GameObject canvasGame;

	[Header("Player")]
	[SerializeField] private GameObject[] playerPrefabs;
	[SerializeField] private Transform[] spawnPoints;

	private PlayerController[] playerControllers = new PlayerController[Constants.NB_MAX_PLAYERS];

	// Use this for initialization
	override public void Start ()
	{
		canvasGame.SetActive (true);
		canvasPause.SetActive (false);
		base.Start ();

		for (int i = 0; i < playerPrefabs.Length; ++i)
		{
			GameObject go = (GameObject)Instantiate (playerPrefabs [i], spawnPoints [i].position, spawnPoints[i].rotation);
			playerControllers [i] = go.GetComponent<PlayerController> ();
			go.GetComponent<PlayerController> ().PlayerIndex = i + 1;
		}
	}
	
	override public void SetPause()
	{
		base.SetPause ();
		canvasPause.SetActive (Paused);
	}

	override public void Update()
	{
		if (Input.GetKeyDown(KeyCode.P))
		{
			playerControllers [0].GetComponent<PlayerController> ().shiftMoves (1);
		}
	}
}

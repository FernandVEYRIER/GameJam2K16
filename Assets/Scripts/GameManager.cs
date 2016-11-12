using UnityEngine;
using System.Collections;

public class GameManager : AGameManager {

	[Header("GUI")]
	[SerializeField] private GameObject canvasPause;
	[SerializeField] private GameObject canvasGame;

	[Header("Player")]
	[SerializeField] private GameObject[] playerPrefabs;
	[SerializeField] private Transform[] spawnPoints;

	// Use this for initialization
	override public void Start ()
	{
		canvasGame.SetActive (true);
		canvasPause.SetActive (false);
		base.Start ();

		for (int i = 0; i < playerPrefabs.Length; ++i)
		{
			GameObject go = (GameObject)Instantiate (playerPrefabs [i], spawnPoints [i].position, spawnPoints[i].rotation);
			go.GetComponent<PlayerCharacter> ().PlayerIndex = i + 1;
		}
	}
	
	override public void SetPause()
	{
		base.SetPause ();
		canvasPause.SetActive (Paused);
	}
}

using UnityEngine;
using System.Collections;

public class GameManager : AGameManager {

	[Header("GUI")]
	[SerializeField] private GameObject canvasPause;
	[SerializeField] private GameObject canvasGame;

	// Use this for initialization
	override public void Start ()
	{
		canvasGame.SetActive (true);
		canvasPause.SetActive (false);
		base.Start ();
	}
	
	override public void SetPause()
	{
		base.SetPause ();
		canvasPause.SetActive (Paused);
	}
}

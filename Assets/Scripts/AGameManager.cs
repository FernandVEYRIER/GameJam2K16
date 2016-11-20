using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using Assets.Scripts;

public abstract class AGameManager : MonoBehaviour {
	
	private bool _paused = false;
	private GameState _gameState = GameState.WARMUP;
	private GameState _prevGameState = GameState.WARMUP;

	private static AGameManager _gm = null;

	public static AGameManager GM
	{ get { return _gm; }}

	public GameState State
	{ get { return _gameState; }}

	virtual public void Awake()
	{
		if (_gm == null)
		{
			_gm = this;
		}
		else
		{
			Destroy (this);
		}
	}

	virtual protected void UpdateState(GameState state)
	{
		_prevGameState = _gameState;
		_gameState = state;
	}

	virtual public void Start()
	{
		
	}

	virtual public void Update()
	{
		
	}

	public bool Paused
	{
		get { return _paused; }
	}

	virtual public void SetPause()
	{
		_paused = !_paused;
		if (_paused)
			UpdateState (GameState.PAUSE);
		else
			UpdateState (_prevGameState);
		
		Time.timeScale = (_paused) ? 0 : 1;
	}

	public void EndGame()
	{
		Debug.Log ("Ended the game !");
		UpdateState (GameState.END);
	}

	virtual public void OnPlay()
	{
		
	}

	virtual public void OnQuit()
	{
		Application.Quit ();
	}

	virtual public void LoadLevel(int level)
	{
		SceneManager.LoadSceneAsync (level);
	}
}

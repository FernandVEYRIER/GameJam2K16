using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public abstract class AGameManager : MonoBehaviour {
	
	private bool _paused = false;

	private static AGameManager _gm = null;

	public static AGameManager GM
	{ get { return _gm; }}

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
		SceneManager.LoadScene (level);
	}
}

using UnityEngine;
using System.Collections;
using Assets.Scripts;

public interface IGameManager {

	bool Paused { get; }

	GameState State { get; }

	void SetPause();
	void OnPlay ();
	void OnQuit ();
	void LoadLevel (int level);
}

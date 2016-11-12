using UnityEngine;
using System.Collections;

public interface IGameManager {

	bool Paused { get; }

	void SetPause();
	void OnPlay ();
	void OnQuit ();
	void LoadLevel (int level);
}

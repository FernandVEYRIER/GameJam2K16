using UnityEngine;
using System.Collections;

public class PlayerCharacter : MonoBehaviour
{
	private int _playerIndex = -1;

	public int PlayerIndex
	{
		get { return _playerIndex; }
		set { _playerIndex = (_playerIndex < 0) ? value : _playerIndex; }
	}
}

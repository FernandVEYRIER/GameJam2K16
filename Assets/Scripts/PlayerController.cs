using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class PlayerController : MonoBehaviour
{
	private int _playerIndex = -1;
	private List<string> _moves = new List<string>() {"Up", "Right", "Down", "Left"};

    public void shiftMoves(int shiftBy, bool counterClockwise = false)
    {
        if (counterClockwise)
        {
            for (int i = 0; i < shiftBy; i++)
            {
                var tmp = _moves[_moves.Count - 1];
                _moves[_moves.Count - 1] = _moves[0];
                _moves[0] = tmp;
            }
        }
        else
        {
            for (int i = 0; i < shiftBy; i++)
            {
                var tmp = _moves[0];
                _moves[0] = _moves[_moves.Count - 1];
                _moves[_moves.Count - 1] = tmp;
            }
        }
		foreach (var v in _moves)
			Debug.Log (v);
	}

	public int PlayerIndex
	{
		get { return _playerIndex; }
		set { _playerIndex = (_playerIndex < 0) ? value : _playerIndex; }
	}
}

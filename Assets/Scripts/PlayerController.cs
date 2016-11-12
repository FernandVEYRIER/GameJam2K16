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
            if (_moves.Count > shiftBy)
            {
                var result = _moves.GetRange(_moves.Count - shiftBy, shiftBy);
                result.AddRange(_moves.GetRange(0, _moves.Count - shiftBy));
                _moves = result;
            }

        }
        else
        {
            if (_moves.Count > shiftBy)
            {
                var result = _moves.GetRange(shiftBy, _moves.Count - shiftBy);
                result.AddRange(_moves.GetRange(0, shiftBy));
                _moves = result;
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

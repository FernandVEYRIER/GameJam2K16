using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

public class PlayerCharacter : MonoBehaviour
{
	private int _playerIndex = -1;
    private List<string> _moves = new List<string>();

    void Start()
    {
        if(gameObject.transform.eulerAngles.z == 0)
        {
            _moves = new List<string> { "Up", "Right", "Down", "Left" };
        }
        else if (gameObject.transform.eulerAngles.z == 90)
        {
            _moves = new List<string> { "Right", "Down", "Left", "Up" };
        }
        else if (gameObject.transform.eulerAngles.z == 180)
        {
            _moves = new List<string> { "Down", "Left", "Up", "Right" };
        }
        else if (gameObject.transform.eulerAngles.z == 260)
        {
            _moves = new List<string> { "Left", "Up", "Right", "Down" };
        }
    }

    public void shiftMoves(int shiftBy, bool counterClockwise = false)
    {
        if (counterClockwise)
        {
            var result = _moves.GetRange(_moves.Count - shiftBy, shiftBy);
            result.AddRange(_moves.GetRange(0, _moves.Count - shiftBy));
            _moves = result;
        }
        else
        {
            var result = _moves.GetRange(shiftBy, _moves.Count - shiftBy);
            result.AddRange(_moves.GetRange(0, shiftBy));
            _moves = result;
        }
    }

	public int PlayerIndex
	{
		get { return _playerIndex; }
		set { _playerIndex = (_playerIndex < 0) ? value : _playerIndex; }
	}
}

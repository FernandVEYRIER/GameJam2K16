using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using Assets.Scripts;

public class PlayerController : MonoBehaviour
{
    public bool hasShield = false;

	private int _playerIndex = -1;
    private Direction _position;
	private List<string> _moves = new List<string>() {"Up", "Right", "Down", "Left"};
	private IPowerUp currPowerUp = null;

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
	}

	void OnTriggerEnter2D(Collider2D col)
	{
		if (col.tag == "PowerUp")
		{
            Debug.Log("I am " + _playerIndex + " and I now have the powerup");
			currPowerUp = col.GetComponent<APowerUp> ();
			Destroy (col.gameObject);
		}
	}

	public void UsePowerUp(Direction d)
	{
        Debug.Log("i am _playerIndex " + _playerIndex);
        if (currPowerUp != null)
		{
            Debug.Log("hello again _playerIndex " +_playerIndex);
			currPowerUp.Use (d, _playerIndex);
			if (currPowerUp.RemainingUsages <= 0)
				currPowerUp = null;
		}
	}

    public void TakeDamage()
    {
        //TODO
    }

    public void DodgeObstacle()
    {
        //TODO
    }

	public int PlayerIndex
	{
		get { return _playerIndex; }
		set { _playerIndex = (_playerIndex < 0) ? value : _playerIndex; }
	}

    public Direction Position
    {
        get { return _position; }
        set { _position = value; }
    }
}

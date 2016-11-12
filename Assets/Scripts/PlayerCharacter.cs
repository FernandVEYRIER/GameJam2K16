using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class PlayerCharacter : MonoBehaviour
{
	[SerializeField] private int _playerIndex = -1;
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

	public int PlayerIndex
	{
		get { return _playerIndex; }
		set { _playerIndex = (_playerIndex < 0) ? value : _playerIndex; }
	}
}

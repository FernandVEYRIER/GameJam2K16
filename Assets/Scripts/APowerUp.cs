using UnityEngine;
using System.Collections;
using Assets.Scripts;

public abstract class APowerUp : MonoBehaviour, IPowerUp {

	[SerializeField] private int _remainingUsages;
	private int _sender = -1;
	private int _target = -1;

	public int Sender {
		get {
			return _sender;
		}
		set {
			_sender = (value < 0) ? -1 : value;
		}
	}

	public int Target {
		get {
			return _target;
		}
		set {
			_target = (value < 0) ? -1 : value;
		}
	}

	virtual public bool Use (Direction dir = Direction.TOP, int sender = -1, int target = -1)
	{
		_sender = sender;
		_target = target;
		if (_remainingUsages <= 0)
			return false;
		--_remainingUsages;
		return true;
	}

	public int RemainingUsages {
		get {
			return _remainingUsages;
		}
	}

	virtual public void Add()
	{
		++_remainingUsages;
	}
}

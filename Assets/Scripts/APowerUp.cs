using UnityEngine;
using System.Collections;

public abstract class APowerUp : MonoBehaviour, IPowerUp {

	[SerializeField] private int _remainingUsages;

	public bool Use ()
	{
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

	public void Add()
	{
		++_remainingUsages;
	}
}

using UnityEngine;
using System.Collections;
using Assets.Scripts;

public interface IPowerUp {

	int RemainingUsages {
		get;
	}

	int Sender {
		get;
		set;
	}

	int Target {
		get;
		set;
	}

	Sprite sprite {
		get;
	}

	bool Use (Direction dir = Direction.TOP, int sender = -1, int target = -1);
	void Add ();
}
using UnityEngine;
using System.Collections;

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

	bool Use (int sender = -1, int target = -1);
	void Add ();
}
using UnityEngine;
using System.Collections;

public interface IPowerUp {

	int RemainingUsages {
		get;
	}

	bool Use ();
	void Add ();
}
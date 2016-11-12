using UnityEngine;
using System.Collections;

public class PowerUpRotate : APowerUp {

	override public bool Use(int sender = -1, int target = -1)
	{
		if (base.Use(sender, target))
		{
			((GameManager)GameManager.GM).RotateMap ();
			return true;
		}
		return false;
	}
}

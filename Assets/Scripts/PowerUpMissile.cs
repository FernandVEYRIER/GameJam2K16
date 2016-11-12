using UnityEngine;
using System.Collections;
using Assets.Scripts;

public class PowerUpMissile : APowerUp {
	
	public override bool Use (Direction dir = Direction.TOP, int sender = -1, int target = -1)
	{
		return base.Use (dir, sender, target);
	}
}
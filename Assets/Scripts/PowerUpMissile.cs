using UnityEngine;
using System.Collections;
using Assets.Scripts;

public class PowerUpMissile : APowerUp {

	[SerializeField] private GameObject missilePrefab;
	
	public override bool Use (Direction dir = Direction.TOP, int sender = -1, int target = -1)
	{
		if (base.Use())
		{
			Instantiate (missilePrefab, transform.GetChild(0).position, transform.GetChild(0).rotation);
			return true;
		}
		return false;
	}
}
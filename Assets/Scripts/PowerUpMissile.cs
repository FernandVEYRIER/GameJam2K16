using UnityEngine;
using System.Collections;
using Assets.Scripts;

public class PowerUpMissile : APowerUp {

	[SerializeField] private GameObject missilePrefab;
	
	public override bool Use (Direction dir = Direction.TOP, int sender = -1, int target = -1)
	{
		if (base.Use())
		{
			GameObject go = (GameObject)Instantiate (missilePrefab, transform.position, transform.rotation);
			go.GetComponent<MissileController> ().targetID = target;
			return true;
		}
		return false;
	}
}
using UnityEngine;
using System.Collections;
using Assets.Scripts;

public class PowerUpMissile : APowerUp {

	[SerializeField] private GameObject missilePrefab;

	public override bool Use (Direction dir = Direction.TOP, int sender = -1, int target = -1)
	{
		if (base.Use())
		{
			GameObject.Find ("CanonObj").GetComponent<CanonManager> ().Shoot ();
			//Transform startPoint = GameObject.Find ("Player" + (sender + 1)).transform.GetChild(0);
			//Instantiate (missilePrefab, startPoint.position, startPoint.rotation);
            ((GameManager)GameManager.GM).AS.PlayOneShot(((GameManager)GameManager.GM).missileSound);

            return true;
		}
		return false;
	}
}
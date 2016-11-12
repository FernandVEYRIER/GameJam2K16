using UnityEngine;
using System.Collections;
public class PowerUpReflector : APowerUp {

	[SerializeField] private float radius = 2;

	public override bool Use (Assets.Scripts.Direction dir = Assets.Scripts.Direction.TOP, int sender = -1, int target = -1)
	{
		if (base.Use(dir, sender, target))
		{
			Collider2D[] objs = Physics2D.OverlapCircleAll (this.transform.position, radius);

			foreach (Collider2D go in objs)
			{
				if (go.tag == "Missile")
				{
					go.GetComponent<MissileController> ().InvertTarget ();
				}
			}
			return true;
		}
		return false;
	}
}

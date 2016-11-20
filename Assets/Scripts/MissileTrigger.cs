using UnityEngine;
using System.Collections;

public class MissileTrigger : MonoBehaviour {

	[SerializeField] private MapGenerator mapGenerator;

	void OnTriggerEnter2D(Collider2D col)
	{
		GameObject empty = new GameObject ("MissileP" + mapGenerator.id);
		empty.transform.position = col.transform.position;
		empty.transform.rotation = transform.rotation;
		col.transform.SetParent (empty.transform);
		mapGenerator.PushObject (empty);
	}
}

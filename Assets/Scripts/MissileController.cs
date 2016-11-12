using UnityEngine;
using System.Collections;

public class MissileController : MonoBehaviour {

	[HideInInspector] public int targetID = -1;
	public float speed = 10;

	private Transform currTarget;

	// Use this for initialization
	void Start () {
		currTarget = GameObject.Find ("Player" + targetID).transform;
	}
	
	// Update is called once per frame
	void Update ()
	{
		transform.position = Vector3.MoveTowards (transform.position, currTarget.position, speed);
	}

	bool UpdateTarget(int id)
	{
		GameObject go = GameObject.Find ("Player" + id);
		if (go == null)
			return false;
		currTarget = go.transform;
		return true;
	}
}

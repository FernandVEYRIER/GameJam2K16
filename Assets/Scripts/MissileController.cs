using UnityEngine;
using System.Collections;
using Assets.Scripts;

public class MissileController : MonoBehaviour {

	private Direction targetDir = Direction.TOP;
	public float speed = 10;

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update ()
	{
		transform.Translate (transform.forward * speed);
	}

	public bool UpdateTarget(Direction dir)
	{
		targetDir = dir;
		return true;
	}
}

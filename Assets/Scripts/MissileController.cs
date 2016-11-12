using UnityEngine;
using System.Collections;
using Assets.Scripts;

public class MissileController : MonoBehaviour {

	public float speed = 10;
	Direction currentDir = Direction.TOP;

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update ()
	{
		transform.position += transform.up * speed * Time.deltaTime;
	}

	public bool UpdateTarget(Direction dir)
	{
		switch (dir)
		{
		case Direction.TOP:
			transform.localRotation = Quaternion.Euler (0, 0, 0);
			break;
		case Direction.DOWN:
			transform.localRotation = Quaternion.Euler(0, 0, 180);
			break;
		case Direction.LEFT:
			transform.localRotation = Quaternion.Euler (0, 0, 270);
			break;
		case Direction.RIGHT:
			transform.localRotation = Quaternion.Euler (0, 0, 90);
			break;
		}
		currentDir = dir;
		return true;
	}

	public void InvertTarget()
	{
		int curr = (int)currentDir;

		curr *= -1;
		UpdateTarget ((Direction)curr);
	}
}

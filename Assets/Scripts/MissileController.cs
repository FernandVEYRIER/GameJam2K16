using UnityEngine;
using System.Collections;
using Assets.Scripts;

public class MissileController : MonoBehaviour {

	[SerializeField] private GameObject explosionPrefab;

	public float speed = 10;
	Direction currentDir = Direction.TOP;
    Vector2 targetCoordinateTop = new Vector2(47, 50);

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

	void OnTriggerEnter2D(Collider2D col)
	{
		if (col.gameObject.tag == "Ground")
		{
            Debug.Log("hi");
			//Instantiate (explosionPrefab, transform.position, Quaternion.identity);
			Destroy (gameObject);
		}
	}
}

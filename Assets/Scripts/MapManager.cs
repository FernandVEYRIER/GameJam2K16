using UnityEngine;
using System.Collections;

public class MapManager : MonoBehaviour {

	[SerializeField] private GameObject[] sides;
	[SerializeField] private float startDist;
	[SerializeField] private float velocity;

	Vector3[] tr;
	private Vector3[] vel;

	// Use this for initialization
	void Start () {
		if (sides.Length > 0)
		{
			tr = new Vector3[sides.Length];
			vel = new Vector3[sides.Length];
			for (int i = 0; i < sides.Length; ++i)
			{
				tr [i] = sides [i].transform.position;
				sides [i].transform.position += sides [i].transform.right * startDist;
			}
		}
	}
	
	// Update is called once per frame
	void Update () {
		for (int i = 0; i <sides.Length; ++i)
		{
			sides [i].transform.position = Vector3.SmoothDamp (sides [i].transform.position, tr [i], ref vel[i], velocity);
		}
	}
}

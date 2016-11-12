using UnityEngine;
using System.Collections;
using Assets.Scripts;

public class MapManager : MonoBehaviour {

	[SerializeField] private GameObject[] sides;
	[SerializeField] private MapGenerator[] spawners;
	[SerializeField] private float startDist;
	[SerializeField] private float velocity;

	[SerializeField] private float minSpawnDelay = 2f;
	[SerializeField] private GameObject obstaclePrefab;

	private Vector3[] tr;
	private Vector3[] vel;
	private float currDelay;
	private float distance = 0;

	// Use this for initialization
	void Start () {
		currDelay = minSpawnDelay;
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

		if (GameManager.GM.State == GameState.PLAY)
		{
			if (currDelay <= 0)
			{
				GenerateMap ();
				currDelay = minSpawnDelay;
			}
			else
				currDelay -= Time.deltaTime;
			++distance;
		}
	}

	void GenerateMap()
	{
		bool isWall = Random.Range (0, 2) == 0;

		foreach (MapGenerator m in spawners)
		{
			m.PushTerrain (new Obstacle((isWall) ? obstaclePrefab : null, distance));
		}
	}
}

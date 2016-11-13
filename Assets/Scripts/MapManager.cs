using UnityEngine;
using System.Collections;
using Assets.Scripts;

public class MapManager : MonoBehaviour {

	[Header("Terrain")]
	[SerializeField] private GameObject[] sides;
	[SerializeField] private MapGenerator[] spawners;
	[SerializeField] private float startDist;
	[SerializeField] private float velocity;
	[SerializeField] private float scrollVelocity = 1;

	[Header("Objects")]
	[SerializeField] private float minSpawnDelay = 2f;
	[SerializeField] private GameObject obstaclePrefab;
	[SerializeField] private GameObject[] powerupPrefabs;

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
				sides [i].transform.position -= sides [i].transform.right * startDist;
			}
		}

		foreach (MapGenerator m in spawners)
			m.currVelocity = scrollVelocity;
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
				Debug.Log ("Generate Map");
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
			Debug.Log ("Wall ? " + isWall);
			m.PushTerrain (new Obstacle((isWall) ? obstaclePrefab : powerupPrefabs[Random.Range(0, powerupPrefabs.Length)], distance));
		}
	}

	public void TakeSlow(int playerID)
	{
		spawners [playerID].TakeSlow ();
	}
}

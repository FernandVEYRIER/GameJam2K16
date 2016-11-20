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
	[SerializeField] private float endDist = 1000f;

	[Header("Objects")]
	[SerializeField] private float minSpawnDelay = 2f;
	[SerializeField] private GameObject[] obstaclePrefab;
	[SerializeField] private GameObject[] powerupPrefabs;

	private Vector3[] tr;
	private Vector3[] vel;
	private float currDelay;
	private float distance = 0;

	public float EndDistance
	{ get{ return endDist; }}

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

		for (int i = 0; i < spawners.Length; ++i)
		{
			spawners[i].currVelocity = scrollVelocity;
			spawners[i].endDist = endDist;
			spawners[i].id = i + 1;
		}
	}
	
	// Update is called once per frame
	void Update () {
		for (int i = 0; i < sides.Length; ++i)
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
		bool isWall = Random.Range (0, 6) < 4;

		foreach (MapGenerator m in spawners)
		{
			m.PushTerrain (new Obstacle((isWall) ? obstaclePrefab[Random.Range(0, obstaclePrefab.Length)] : powerupPrefabs[Random.Range(0, powerupPrefabs.Length)], distance));
		}
	}

	public void ClearMaps()
	{
		foreach (MapGenerator m in spawners)
		{
			m.ClearTerrain ();
		}
	}

	public void TakeSlow(int playerID)
	{
		spawners [playerID].TakeSlow ();
	}
}

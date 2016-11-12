using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Obstacle {
	public GameObject obstaclePrefab = null;
	public float objDistance = 0;

	public Obstacle(GameObject prefab = null, float dist = 0)
	{
		obstaclePrefab = prefab;
		objDistance = dist;
	}
}

public class MapGenerator : MonoBehaviour {

	[SerializeField] private Transform spawnPoint;
	private float distance = 0;
	private List<Obstacle> terrainList = new List<Obstacle> ();
	private float currVelocity = 1;
	private List<GameObject> _objects = new List<GameObject> ();
	
	// Update is called once per frame
	void Update () {
		
		if (GameManager.GM.State == Assets.Scripts.GameState.PLAY)
		{
			if (terrainList.Count > 0 && terrainList[0].objDistance <= distance)
			{
				if (terrainList[0].obstaclePrefab != null)
				{
					_objects.Add((GameObject)Instantiate (terrainList [0].obstaclePrefab, spawnPoint.transform.position, spawnPoint.transform.rotation));
				}
				terrainList.RemoveAt (0);
			}
			distance += currVelocity;
			foreach (GameObject g in _objects)
			{
				if (g != null)
					g.transform.position += g.transform.up * currVelocity;
			}
		}
	
	}

	public void PushTerrain(Obstacle obs)
	{
		terrainList.Add (obs);
	}

	public void DestroyObject(GameObject go)
	{
		if (_objects.Remove (go))
			Destroy (go);
	}
}

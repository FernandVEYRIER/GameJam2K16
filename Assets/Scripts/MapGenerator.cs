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
	[HideInInspector] public float currVelocity = 1;
	private List<GameObject> _objects = new List<GameObject> ();
	private AnimateSprite _animateSprite;
	private float initVel;
	[HideInInspector] public float endDist;
	[HideInInspector] public int id;

	const float RATIO = 0.285f;

	void Start()
	{
		_animateSprite = GetComponent<AnimateSprite> ();
		_animateSprite.scrollSpeed = currVelocity * RATIO;
		initVel = currVelocity;
	}

	// Update is called once per frame
	void Update () {
		if (GameManager.GM.State == Assets.Scripts.GameState.PLAY)
		{
			_animateSprite.scrollSpeed = currVelocity * RATIO;
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

			// If the player reached the end
			if (distance >= endDist)
			{
				distance = endDist;
				GameManager.GM.EndGame (id);
			}
		}
	}

    public float GetDistance()
    {
        return distance;
    }

	public void PushTerrain(Obstacle obs)
	{
		terrainList.Add (obs);
	}

	public void PushObject(GameObject obj)
	{
		_objects.Add (obj);
	}

	public void DestroyObject(GameObject go)
	{
		if (_objects.Remove (go))
			Destroy (go);
	}

	public void TakeSlow()
	{
		StopAllCoroutines ();
		StartCoroutine (HitObstacleRoutine ());
	}

	IEnumerator HitObstacleRoutine()
	{
		for (; currVelocity >= 0; currVelocity -= initVel / 20f)
		{
			yield return new WaitForSeconds (0.025f);
		}

		for (currVelocity = 0; currVelocity < initVel; currVelocity += initVel / 20f)
		{
			yield return new WaitForSeconds (0.025f);
		}

		currVelocity = initVel;
	}

	public void ClearTerrain()
	{
		foreach (GameObject go in _objects)
		{
			Destroy (go);
		}
		terrainList.Clear ();
	}
}

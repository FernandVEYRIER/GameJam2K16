using UnityEngine;
using System.Collections;
using Assets.Scripts;

public class CanonManager : MonoBehaviour {

	[SerializeField] private GameObject missilePrefab;
	[SerializeField] private GameObject _canon;
	[SerializeField] private float rotationDelay = 1f;
	[SerializeField] private float speed = 1f;

	private float currDelay;
	private Quaternion targetRotation;

	// Use this for initialization
	void Start () {
		currDelay = rotationDelay;
		targetRotation = transform.rotation;
	}
	
	// Update is called once per frame
	void Update () {
		if (GameManager.GM.State == GameState.PLAY)
		{
			if (currDelay < 0)
			{
				currDelay = rotationDelay;
				targetRotation *= Quaternion.AngleAxis (90, Vector3.forward);
			}
			currDelay -= Time.deltaTime;
		}
		transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, Time.deltaTime * speed);
	}

	public void Shoot()
	{
		// TODO
	}
}

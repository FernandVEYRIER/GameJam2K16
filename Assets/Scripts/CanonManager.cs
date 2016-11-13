using UnityEngine;
using System.Collections;
using Assets.Scripts;
using System.Collections.Generic;
using UnityEngine.UI;

public class CanonManager : MonoBehaviour {

	[Header("GUI")]
	[SerializeField] private Text textMissile;

	[Header("Canon")]
	[SerializeField] private GameObject missilePrefab;
	[SerializeField] private GameObject _canon;
	[SerializeField] private float rotationDelay = 1f;
	[SerializeField] private float speed = 1f;

	private float currDelay;
	private Quaternion targetRotation;

	private Queue<GameObject> missilesToLaunch = new Queue<GameObject>();
	private bool hasShot = false;

	void Start () {
		currDelay = rotationDelay;
		targetRotation = transform.rotation;
	}
	
	void Update () {
		if (Input.GetKeyDown(KeyCode.G))
		{
			Shoot ();
		}

		if (GameManager.GM.State == GameState.PLAY)
		{
			if (currDelay < 0)
			{
				hasShot = false;
				currDelay = rotationDelay;
				targetRotation *= Quaternion.AngleAxis (90, Vector3.forward);

				if (!hasShot)
				{
					hasShot = true;
					if (missilesToLaunch.Count > 0)
					{
						Instantiate (missilesToLaunch.Dequeue (), _canon.transform.position, _canon.transform.rotation);
					}
				}
			}
			currDelay -= Time.deltaTime;
			textMissile.text = missilesToLaunch.Count.ToString();
		}
		else
		{
			textMissile.text = "";
		}

		transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, Time.deltaTime * speed);
	}

	public void Shoot()
	{
		missilesToLaunch.Enqueue (missilePrefab);
	}
}

using UnityEngine;
using System.Collections;
using Assets.Scripts;
using UnityEngine.UI;

public class GameManager : AGameManager {

    public AudioSource AS = new AudioSource();
    public AudioClip shieldSound;
    public AudioClip reflectorSound;
    public AudioClip reflectedSound;
    public AudioClip rotationSound;
    public AudioClip missileSound;

    [Header("GUI")]
	[SerializeField] private GameObject canvasPause;
	[SerializeField] private GameObject canvasGame;
	[SerializeField] private Text textCounter;

	[Header("Player")]
	[SerializeField] private GameObject[] playerPrefabs;
	[SerializeField] private Transform[] spawnPoints;
	[SerializeField] private float gravity = -80f;

	[Header("Map")]
	[SerializeField] private RotateMap map;
	[SerializeField] private MapManager mapManager;

	private PlayerController[] playerControllers = new PlayerController[Constants.NB_MAX_PLAYERS];
    
	// Use this for initialization
	override public void Start ()
	{
        AS = GetComponent<AudioSource>();
		canvasGame.SetActive (true);
		canvasPause.SetActive (false);
		base.Start ();

		mapManager = GameObject.FindGameObjectWithTag ("MapManager").GetComponent<MapManager> ();

		for (int i = 0; i < playerPrefabs.Length; ++i)
		{
			GameObject go = (GameObject)Instantiate (playerPrefabs [i], spawnPoints [i].position, spawnPoints[i].rotation);
			go.name = "Player" + (i + 1);
			playerControllers [i] = go.GetComponent<PlayerController> ();
            if (i > 0)
                playerControllers[i].shiftMoves(i, true);
			go.GetComponent<PlayerController> ().PlayerIndex = i;
			go.GetComponent<ConstantForce2D> ().relativeForce = Vector2.zero;
		}

		StartCoroutine (GameStartRoutine ());
	}

	IEnumerator GameStartRoutine()
	{
		UpdateState (GameState.WARMUP);
		for (int i = 3; i > 0; --i)
		{
			textCounter.text = i.ToString();
			yield return new WaitForSeconds (1);
		}
		textCounter.text = "";
		UpdateState (GameState.PLAY);
		foreach (PlayerController p in playerControllers)
		{
			p.GetComponent<ConstantForce2D> ().relativeForce = new Vector2(0, gravity);
		}
	}
	
	override public void SetPause()
	{
		base.SetPause ();
		canvasPause.SetActive (Paused);
	}

	public void RotateMap(bool clockwise = true)
	{
        for (int i = 0; i < playerControllers.Length; i++)
            playerControllers[i].shiftMoves(1, !clockwise);
		map.rotate ((clockwise) ? global::RotateMap.State.right : global::RotateMap.State.left);
	}

    public void GiveShield(Direction d, int sender)
    {
        int target = GetPlayerIndexFromDirection(d);
        playerControllers[target].hasShield = true;
    }

    public int GetPlayerIndexFromDirection(Direction d)
    {
        for (int i = 0; i < playerControllers.Length; i++)
        {
            if (playerControllers[i].Position == d)
                return i;
        }
        return -1; //let us hope that this never happens
    }

	public void PlayerTakeDamage(int playerID)
	{
		mapManager.TakeSlow (playerID);
	}
}

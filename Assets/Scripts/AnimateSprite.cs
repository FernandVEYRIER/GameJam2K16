using UnityEngine;
using System.Collections;

public class AnimateSprite : MonoBehaviour {

	[HideInInspector] public float scrollSpeed = 0.5F;
    private Renderer rend;
	private float offset = 0;

    void Start()
    {
        rend = GetComponent<Renderer>();
    }

    void Update () {
		if (GameManager.GM.State == Assets.Scripts.GameState.PLAY)
		{
			offset += Time.deltaTime * scrollSpeed;
			rend.material.SetTextureOffset ("_MainTex", new Vector2 (offset, 0));
		}
    }
}

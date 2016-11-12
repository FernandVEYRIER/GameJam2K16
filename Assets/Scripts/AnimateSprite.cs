using UnityEngine;
using System.Collections;

public class AnimateSprite : MonoBehaviour {

    public float scrollSpeed = 0.5F;
    private Renderer rend;
    void Start()
    {
        rend = GetComponent<Renderer>();
    }

    void Update () {
		if (GameManager.GM.State == Assets.Scripts.GameState.PLAY)
		{
			float offset = Time.time * scrollSpeed;
			rend.material.SetTextureOffset ("_MainTex", new Vector2 (offset, 0));
		}
    }
}

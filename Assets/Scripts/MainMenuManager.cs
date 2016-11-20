using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class MainMenuManager : AGameManager {
	
	[SerializeField] private GameObject credits;

    public GameObject[] buttons;
    private int current;
    private bool selected;
    private Color grey = new Color(0.9f, 0.9f, 0.9f);
    public RotateMap map = null;

    public override void Start()
    {
        base.Start();
		credits.SetActive (false);
        current = 0;
        selected = false;
        if (!map)
            map = Camera.main.GetComponent<RotateMap>();
        InvokeRepeating("Selected", 0, 0.5f);
    }

    override public void Update()
    {
        base.Update();
        float axis = Input.GetAxis("P0LeftHorizontal");

        if (Input.GetAxis("P0ButtonA") != 0 && !selected && current == 3)
        {
            selected = true;
            LoadLevel(1);
        }
		else if (Input.GetAxis("P0ButtonA") != 0 && !selected && current == 2)
		{
			selected = true;
			ShowCredits ();
		}
		else if (Input.GetAxis("P0ButtonA") != 0 && !selected && current == 1)
		{
			selected = true;
			OnQuit ();
		}
        else if (map.getState() == RotateMap.State.none)
        {
            if (axis > 0)
                Previous();
            else if (axis < 0)
                Next();
        }
        else
            selected = false;
    }

    void Previous()
    {
        buttons[current].GetComponent<SpriteRenderer>().material.color = Color.white;
        --current;
        if (current < 0)
            current = buttons.Length - 1;
    }

    void Next()
    {
        buttons[current].GetComponent<SpriteRenderer>().material.color = Color.white;
        ++current;
        if (current >= buttons.Length)
            current = 0;
    }

    void Selected()
    {
        if (selected)
        {
            selected = false;
            buttons[current].GetComponent<SpriteRenderer>().material.color = Color.white;
        }
        else
        {
            selected = true;
            buttons[current].GetComponent<SpriteRenderer>().material.color = grey;
        }
    }

    override public void LoadLevel(int level)
    {
        StartCoroutine("FadeLevel", level);
    }

    IEnumerator FadeLevel(int level)
    {
        float fadeTime = GetComponent<Fading>().BeginFade(1);
        yield return new WaitForSeconds(fadeTime);
        SceneManager.LoadScene(level);
    }

	public void ShowCredits()
	{
		credits.SetActive (!credits.activeSelf);
	}
}

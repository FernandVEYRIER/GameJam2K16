using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class MainMenuManager : AGameManager {
    public GameObject[] buttons;
    private int current;
    private bool selected;
    private Color grey = new Color(0.9f, 0.9f, 0.9f);
    public RotateMap map = null;

    public override void Start()
    {
        base.Start();
        current = 0;
        selected = false;
        if (!map)
            map = Camera.main.GetComponent<RotateMap>();
        InvokeRepeating("Selected", 0, 0.5f);
    }

    override public void Update()
    {
        base.Update();
        float axis = Input.GetAxis("Horizontal");
        if (map.getState() == RotateMap.State.none)
        {
            if (axis > 0)
            {
                buttons[current].GetComponent<SpriteRenderer>().material.color = Color.white;
                --current;
                if (current < 0)
                    current = buttons.Length - 1;
            }
            else if (axis < 0)
            {
                buttons[current].GetComponent<SpriteRenderer>().material.color = Color.white;
                ++current;
                if (current >= buttons.Length)
                    current = 0;
            }
        }
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
}

﻿using UnityEngine;
using System.Collections.Generic;
using UnityEngine.UI;

public class MovePlayer : MonoBehaviour
{
    public MapGenerator[] maps;
    public GameObject panel;
    private GameObject[] children;
    private List<KeyValuePair<int, float>> scores = new List<KeyValuePair<int, float>>();
    private Dictionary<int, Transform> TextBox = new Dictionary<int, Transform>();

    void Start()
    {
        int children = panel.transform.childCount;
        for (int i = 0; i < children; ++i)
            TextBox.Add(i, panel.transform.GetChild(i));
        InvokeRepeating("UpdateDisplay", 0, 0.2f);
    }

    void UpdateDisplay()
    {
        int children = transform.childCount;
        scores.Clear();
        for (int i = 0; i < maps.Length; ++i)
            scores.Add(new KeyValuePair<int, float>( i, maps[i].GetDistance()));
        scores.Sort((pair1, pair2) => -pair1.Value.CompareTo(pair2.Value));
        foreach (KeyValuePair<int, float> item in scores)
        {
            TextBox[item.Key].SetAsLastSibling();
            
            Transform current = TextBox[item.Key].GetChild(1);
            int len = current.childCount;
			current.GetComponent<Text>().text = "Player " + (item.Key + 1) + "\n\t" + (item.Value / 10).ToString("0.00") + "m";
            for (int i = 0; i < len; ++i)
				current.GetChild(i).GetComponent<Text>().text = "Player " + (item.Key + 1) + "\n\t" + (item.Value / 10).ToString("0.00") + "m";
        }
    }
}

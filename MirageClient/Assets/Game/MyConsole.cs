using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MyConsole : MonoBehaviour {

    Text mText = null;
	// Use this for initialization
	void Start () {
        var text = GetComponentInChildren<Text>();
        mText = text;
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    public static void Log(string context)
    {
        var csl = Transform.FindObjectOfType<MyConsole>();
        if (csl.mText == null)
            csl.Start();
        csl.mText.text += "\n"+context;
    }
    public static void Color(Color color)
    {
        var csl = Transform.FindObjectOfType<MyConsole>();
        if (csl.mText == null)
            csl.Start();
        csl.mText.color = color;
    }
}
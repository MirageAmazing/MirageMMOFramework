using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Reflection;
using UnityEngine;
using UnityEngine.UI;

public class UIBinding : MonoBehaviour, INotifyPropertyChanged
{

    public Text mText;

    public event PropertyChangedEventHandler PropertyChanged;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void AddBinding(System.Object obj, string name)
    {
        var objType = obj.GetType();
        var memberes = objType.GetMember(name, BindingFlags.GetField);
        if (memberes != null)
        {
            if (memberes[0].GetType() == typeof(string))
            {
                mText.text = memberes[0].ToString();
            }
        }

        var props = objType.GetProperty("", BindingFlags.Public | BindingFlags.Instance);
    }
}

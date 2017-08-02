using UnityEngine;
using UnityEngine.UI;
using Newtonsoft.Json;
using System.Collections.Generic;
using Mirage.DataStructure;
using System.ComponentModel;
using System.Diagnostics;

class test
{
    private float y = 345.905f;
    public float Y { get { return y; } set { y = value; } }
}
public class Test : MonoBehaviour {

	// Use this for initialization
	void Start () {
        BindingList<int> blist = new BindingList<int>();
        List<int> list = new List<int>();
        ObservableCollection<test> coll = new ObservableCollection<test>();

    }
	
	// Update is called once per frame
	void Update () {
		
	}

    [Conditional("Debug")]
    void TTest()
    {
    }
}

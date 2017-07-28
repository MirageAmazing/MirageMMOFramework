using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Newtonsoft.Json;
using System.Text;
using System;
using Newtonsoft.Json.Linq;
class test
{
    public int x = 23;
    private float y = 345.905f;
    public float Y { get { return y; } set { y = value; } }

}
public class Test : MonoBehaviour {

	// Use this for initialization
	void Start () {
        test t = new test();
        t.x = 56;
        t.Y = 123.4546f;
        string str = JsonConvert.SerializeObject(t);

        test tt = JsonConvert.DeserializeObject<test>(str);
        Debug.LogError(tt.x+"  ");
        Debug.LogError(tt.Y);
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}

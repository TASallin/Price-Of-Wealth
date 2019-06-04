using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Timekeeper : MonoBehaviour {
    
	public GameObject sun;
	
	// Use this for initialization
	void Start () {
		sun.transform.localScale = new Vector3(System.Math.Min(Time.timeUnit, 100) / 100f,
    		sun.transform.localScale.y, sun.transform.localScale.z);
	}
	
	// Update is called once per frame
	void Update () {}
}
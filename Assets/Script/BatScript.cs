using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BatScript: MonoBehaviour {
	public bool is_pressing=false;

	public TextController textcontroller;

	public string[] scenarios;


	// Use this for initialization
	void Start () {

	}

	// Update is called once per frame
	void Update () {

	}

	void OnTriggerEnter(Collider other){
		if (other.gameObject.tag == "player") {
			is_pressing = true;
			textcontroller.StartText (scenarios);
			//messagepanel.Start (255);
		}
	}
}

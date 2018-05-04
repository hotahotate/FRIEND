using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterScript2 : MonoBehaviour {

	public TextController textcontroller;

	public string[] scenarios;
	public string[] scenarios2;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnTriggerEnter(Collider other){
		if (PlayerScript.charaFlag) {
			textcontroller.StartText (scenarios2);
		}
		else if (other.gameObject.tag == "player") {
			textcontroller.StartText (scenarios);
			//messagepanel.Start (255);
		}
	}
}

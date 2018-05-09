using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterScript2 : MonoBehaviour {

	public TextController textcontroller;

	public string[] scenarios;
	public string[] scenarios2;
	public GameObject heart;
	bool Bflagflag = false;

	public IventScript iventScript;
	// Use this for initialization
	void Start () {
		heart.SetActive (false);
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnTriggerEnter(Collider other){
		if (PlayerScript.charaFlag||PlayerScript.friendFlag) {
			Bflagflag = true;
			iventScript.StartIvent (Bflagflag, scenarios2);

			heart.transform.position = gameObject.transform.position + new Vector3 (-0.5f, 1f, 0);
			heart.SetActive (true);
			//textcontroller.StartText (scenarios2);
		}
		else if (other.gameObject.tag == "player") {
			Bflagflag = true;
			iventScript.StartIvent (Bflagflag, scenarios);

			heart.transform.position = gameObject.transform.position + new Vector3 (-0.5f, 1f, 0);
			heart.SetActive (true);
			//textcontroller.StartText (scenarios);
			//messagepanel.Start (255);
		}
	}

	void OnTriggerExit(Collider other){
		if(other.gameObject.tag=="player"){ 
			Bflagflag = false;
			heart.SetActive (false);
		}
	}
}

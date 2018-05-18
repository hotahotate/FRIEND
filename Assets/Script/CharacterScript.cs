using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CharacterScript : MonoBehaviour {

	//public TextController textcontroller;
	public string[] scenarios;
	public GameObject heart;
	bool Aflagflag = false;

	public IventScript iventScript;


	// Use this for initialization
	void Start () {
		//heart = GameObject.Find ("HeartIcon");
		heart.SetActive (false);
	}
	
	// Update is called once per frame
	void Update () {
	}

	void OnTriggerEnter(Collider other){
		if (other.gameObject.tag == "player") {
			Aflagflag = true;
			iventScript.StartIvent (Aflagflag, scenarios);

			heart.transform.position = gameObject.transform.position + new Vector3 (-0.5f, 1f, 0);
			heart.SetActive (true);
			//Debug.Log ("OK");
		}
	}

	void OnTriggerExit(Collider other){
		if(other.gameObject.tag=="player"){ 
			Aflagflag = false;
			heart.SetActive (false);
			}
	}

	/*public void AButton(){
		if (Aflagflag) {
			textcontroller.StartText (scenarios);
			Debug.Log("hogehoge");
			Aflagflag = false;
		}
	}*/
}

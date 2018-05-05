using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IventScript : MonoBehaviour {

	public TextController textController;
	bool flag2=false;
	string[] scenarios2;

	// Use this for initialization
	public void StartIvent (bool flag,string[] scenarios) {
		flag2 = flag;
		scenarios2 = scenarios;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void AButton(){
		if (flag2) {
			textController.StartText (scenarios2);
			Debug.Log("hogehoge");
			flag2 = false;
		}
	}
}

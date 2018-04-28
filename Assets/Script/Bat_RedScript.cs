using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Bat_RedScript : MonoBehaviour {

	//public PlayerHP playerHp;
	//github確認用
	float tt;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnTriggerEnter(Collider other){
		if (other.gameObject.tag == "player") {
			Debug.Log ("RedBat");
			//playerHp.flag == 1;
			SceneManager.LoadScene ("Battle");
		}
	}
}

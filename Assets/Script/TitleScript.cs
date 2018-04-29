using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TitleScript : MonoBehaviour {

	//public string key="SaveLife";

	// Use this for initialization
	void Start () {
		//PlayerHP.life = PlayerPrefs.GetInt (key, 10);
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void StartButton(){
		//SceneManager.LoadScene ("Stage1");
	}

	public void SaveButton(){
		//PlayerPrefs.SetInt(key,PlayerHP.life);

	}
}

﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DateControllerScript : MonoBehaviour {

	public string key="SaveLife";
	public string key2="SaveScene";

	public string sceneNo;



	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void StartButton(){
		PlayerHP.life = 10;
		SceneManager.LoadScene ("Stage1");
	}

	public void SaveButton(){
		PlayerPrefs.SetInt(key,PlayerHP.life);
		//PlayerPrefs.SetString(key2,)
		//sceneNo=SceneManager.GetActiveScene().name;
		PlayerPrefs.SetString(sceneNo,SceneManager.GetActiveScene().name);
		Debug.Log (SceneManager.GetActiveScene ().name);
	}

	public void LoadButton(){
		PlayerHP.life = PlayerPrefs.GetInt (key, 10);
		sceneNo = PlayerPrefs.GetString (sceneNo,"Stage1");
		SceneManager.LoadScene (sceneNo);
	}
}

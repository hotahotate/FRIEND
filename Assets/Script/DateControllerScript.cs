using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DateControllerScript : MonoBehaviour {

	public string key="SaveLife";
	public string key2="SaveScene";
	//public string key3="SaveDiary";

	public string sceneNo;



	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void StartButton(){
		PlayerHP.life = 10;
		SceneManager.LoadScene ("Movie1");
		//PoseScript.diary1 = 0;
	}

	public void SaveButton(){
		PlayerPrefs.SetInt(key,PlayerHP.life);
		PlayerPrefs.SetString(sceneNo,SceneManager.GetActiveScene().name);
		//PlayerPrefs.SetInt (key3, PoseScript.diary1);

		Debug.Log (SceneManager.GetActiveScene ().name);
	}

	public void LoadButton(){
		PlayerHP.life = PlayerPrefs.GetInt (key, 10);
		//PoseScript.diary1 = PlayerPrefs.GetInt (key3, 0);
		sceneNo = PlayerPrefs.GetString (sceneNo,"Stage1");
		SceneManager.LoadScene (sceneNo);
	}
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PoseScript : MonoBehaviour {

	GameObject posePanel;
	//GameObject returnButton;
	//GameObject goTitleButton;
	//GameObject itemButton;
	GameObject itemPanel;
	GameObject item1;
	GameObject item2;

	public static bool diary1=false;
	public static bool diary2=false;

	//public int flag=0;

	// Use this for initialization
	void Start () {
		posePanel = GameObject.Find ("PosePanel");
		//returnButton = GameObject.Find ("ReturnButton");
		//goTitleButton = GameObject.Find ("GoTitleButton");
		//itemButton = GameObject.Find ("ItemButton");
		itemPanel = GameObject.Find ("ItemPanel");
		item1 = GameObject.Find ("diary1");
		item2 = GameObject.Find ("diary2");

		posePanel.SetActive (false);
		/*goTitleButton.SetActive (false);
		itemButton.SetActive (false);
		itemPanel.SetActive (false);
		item1.SetActive (false);*/
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void PoseButton(){
		posePanel.SetActive (true);
		itemPanel.SetActive (false);
	}

	public void GoTitleButton(){
		SceneManager.LoadScene ("Title");
	}

	public void ItemButton(){
		itemPanel.SetActive (true);
		if (diary1) {
			item1.SetActive (true);
		} else {
			item1.SetActive (false);
		}

		if (diary2) {
			item2.SetActive (true);
		} else {
			item2.SetActive (false);
		}
	}

	public void ReturnButton(){
		posePanel.SetActive (false);
	}

	public void Flag(int flag){
		if (flag == 1) {
			Debug.Log ("diary1");
			diary1 = true;
		}
		else if(flag==2){
			diary2=true;
		}
	}
}

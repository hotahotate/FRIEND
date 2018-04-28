using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class SelectButtonScript : MonoBehaviour {

	public GameObject enemy;
	public GameObject lifespan;

	private GameObject button1;
	private GameObject button2;
	private GameObject button3;
	private GameObject button4;

	int flag=0;
	int hitCount=3;
	int missCount=0;


	// Use this for initialization
	void Start () {
		button1 = GameObject.Find ("Button1");
		button2 = GameObject.Find ("Button2");
		button3 = GameObject.Find ("Button3");
		button4 = GameObject.Find ("Button4");
	}
	
	// Update is called once per frame
	void Update () {
		if (missCount == 3) {
			SceneManager.LoadScene ("Stage1");
		} else if (hitCount == 0) {
			SceneManager.LoadScene ("Stage2");
		}
	}

	public void Button1(){
		//enemy.SendMessage("Recover");
		if (flag == 2) {
			enemy.SendMessage ("Damage");
			hitCount--;
		} else {
			missCount++;
			lifespan.SendMessage ("DamageFromEnemy");
		}
	}

	public void Button2(){
		//enemy.SendMessage ("Recover");
		missCount++;
		lifespan.SendMessage ("DamageFromEnemy");
	}

	public void Button3(){
		if (flag == 0) {
			enemy.SendMessage ("Damage");
			ChangeWord ();
			flag = 1;
			hitCount--;
		} else {
			//enemy.SendMessage("Recover");
			lifespan.SendMessage ("DamageFromEnemy");
		}
	}

	public void Button4(){
		if (flag == 1) {
			enemy.SendMessage ("Damage");
			ChangeWord2 ();
			flag = 2;
			hitCount--;
		} else {
			//enemy.SendMessage("Recover");
			missCount++;
			lifespan.SendMessage ("DamageFromEnemy");
		}
	}

	public void ChangeWord(){
		button1.GetComponentInChildren<Text>().text="消しゴム";
		button2.GetComponentInChildren<Text>().text="定規";
		button3.GetComponentInChildren<Text>().text="鉛筆";
		button4.GetComponentInChildren<Text>().text="ハンカチ";
	}

	public void ChangeWord2(){
		button1.GetComponentInChildren<Text>().text="バラ";
		button2.GetComponentInChildren<Text>().text="コスモス";
		button3.GetComponentInChildren<Text>().text="ひまわり";
		button4.GetComponentInChildren<Text>().text="桜";
	}

}

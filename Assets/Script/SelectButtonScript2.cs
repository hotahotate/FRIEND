using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class SelectButtonScript2 : MonoBehaviour {

	public GameObject enemy;
	public GameObject lifespan;
	public Text bossText;

	private GameObject button1;
	private GameObject button2;
	private GameObject button3;
	private GameObject button4;

	int flag=0;
	int hitCount=4;
	int missCount=0;
	float timer=0f;


	// Use this for initialization
	void Start () {
		button1 = GameObject.Find ("Button1");
		button2 = GameObject.Find ("Button2");
		button3 = GameObject.Find ("Button3");
		button4 = GameObject.Find ("Button4");
		bossText.text="パーツが欲しければクイズに答えるのじゃ!わしの趣味は?";
	}

	// Update is called once per frame
	void Update () {
		if (missCount == 3) {
			SceneManager.LoadScene ("Stage2");
		} else if (hitCount == 0) {
			timer += Time.deltaTime;
			bossText.text = "コスモ...私が作ったこ。";
			if (timer > 2f) {
				bossText.text="私と暮らすうちに、感情を持つようになってな";
			}
			if(timer>6f){
				bossText.text = "ある日突然、外の世界に行きたいと言って";
			}
			if(timer>8f){
				bossText.text = "出て行ってしまったよ。";
			}
			if (timer > 10f) {
				bossText.text = "君が欲しかったパーツだ。これで、文字が読めるようになるぞ";		
			}
			if (timer > 13f) {
				bossText.text="もしあの子が困っていたら、どうか助けてやってくれ。";
			}
			if (timer > 15f) {
				bossText.text="頼んだよ。";
			}
			if (timer > 18f) {
				if (MoveMobile.EndFlag == 2) {
					SceneManager.LoadScene ("Stage3");
				} else {
					SceneManager.LoadScene ("End1");
				}
			}
		}
	}

	public void Button1(){
		//enemy.SendMessage("Recover");
		if (flag == 0) {
			enemy.SendMessage ("Damage");
			hitCount--;
			ChangeWord ();
			flag = 1;
			bossText.text = "わしの昔の仕事は?";
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
		if (flag == 2) {
			enemy.SendMessage ("Damage");
			ChangeWord3 ();
			flag = 3;
			hitCount--;
			bossText.text = "わしが探しているのは?";
		} else if (flag == 3) {
			enemy.SendMessage ("Damage");
			hitCount--;
		}else {
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
			bossText.text = "この村には何人嘘つきがいる?";
		} else {
			//enemy.SendMessage("Recover");
			missCount++;
			lifespan.SendMessage ("DamageFromEnemy");
		}
	}

	public void ChangeWord(){
		button1.GetComponentInChildren<Text>().text="漁師";
		button2.GetComponentInChildren<Text>().text="大工";
		button3.GetComponentInChildren<Text>().text="村長";
		button4.GetComponentInChildren<Text>().text="工場勤務";
	}

	public void ChangeWord2(){
		button1.GetComponentInChildren<Text>().text="2";
		button2.GetComponentInChildren<Text>().text="3";
		button3.GetComponentInChildren<Text>().text="4";
		button4.GetComponentInChildren<Text>().text="5";
	}

	public void ChangeWord3(){
		button1.GetComponentInChildren<Text>().text="太陽";
		button2.GetComponentInChildren<Text>().text="3号";
		button3.GetComponentInChildren<Text>().text="コスモ";
		button4.GetComponentInChildren<Text>().text="サニー";
	}

}


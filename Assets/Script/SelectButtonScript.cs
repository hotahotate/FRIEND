using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class SelectButtonScript : MonoBehaviour {

	public GameObject enemy;
	public GameObject lifespan;
	public Text enemyText;

	private GameObject button1;
	private GameObject button2;
	private GameObject button3;
	private GameObject button4;

	int flag=0;
	int hitCount=3;
	int missCount=0;
	float timer=0f;


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
			button1.SetActive (false);
			button2.SetActive (false);
			button3.SetActive (false);
			button4.SetActive (false);
			timer += Time.deltaTime;
			enemyText.text="初対面だと思ったが、どうやら私の思い違いだったようだ";
			if (timer > 5f) {
				enemyText.text="この部品を君に譲ろう";
			}
			if (timer > 10f) {
				enemyText.text="ネジを手に入れた!";
			}
			if (timer > 15f) {
				SceneManager.LoadScene ("Stage2");
			}
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
			enemyText.text="私の昔のあだ名は?";
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
			enemyText.text=" 私の最近の悩みは?";
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
		button4.GetComponentInChildren<Text>().text="レッドブルー";
	}

	public void ChangeWord2(){
		button1.GetComponentInChildren<Text>().text="孤独な村人の事";
		button2.GetComponentInChildren<Text>().text="昔の親友の事";
		button3.GetComponentInChildren<Text>().text="息子の事";
		button4.GetComponentInChildren<Text>().text="君の事";
	}

}

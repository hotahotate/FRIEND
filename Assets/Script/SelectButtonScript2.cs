﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class SelectButtonScript2 : MonoBehaviour {

	public GameObject enemy;
	public GameObject lifespan;
	public Text bossText;
	private Animator animator;
	public GameObject robot;

	private GameObject button1;
	private GameObject button2;
	private GameObject button3;
	private GameObject button4;

	int flag=0;
	int hitCount=4;
	int missCount=0;
	float timer=0f;

	public GameObject canvas;
	public GameObject subCnavas;
	public GameObject camera;
	public GameObject subCamera;

	public GameObject yes;
	public GameObject no;

	AudioSource audioYes,audioNo;


	// Use this for initialization
	void Start () {
		button1 = GameObject.Find ("Button1");
		button2 = GameObject.Find ("Button2");
		button3 = GameObject.Find ("Button3");
		button4 = GameObject.Find ("Button4");
		bossText.text="部品が欲しければクイズに答えるのじゃ!わしの趣味は?";

		subCnavas.SetActive (false);
		subCamera.SetActive (false);
		animator = robot.GetComponent<Animator>();

		audioYes = yes.gameObject.GetComponent<AudioSource>();
		audioNo = no.gameObject.GetComponent<AudioSource> ();

	}

	// Update is called once per frame
	void Update () {
		if (missCount == 3) {
			button1.SetActive (false);
			button2.SetActive (false);
			button3.SetActive (false);
			button4.SetActive (false);
			timer += Time.deltaTime;
			bossText.text="残念!また出直しておいで。";
			if (timer > 3f) {
				SceneManager.LoadScene ("Stage2");
			}
		} else if (hitCount == 0) {
			button1.SetActive (false);
			button2.SetActive (false);
			button3.SetActive (false);
			button4.SetActive (false);
			timer += Time.deltaTime;
			bossText.text = "コスモ...私が作ったロボットの名だ。";
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
				bossText.text = "君が欲しかった部品だ。これで文字が読めるよ。";		
			}
			if (timer > 13f) {
				bossText.text="もしあの子が困っていたら、どうか助けてやってくれ。";
			}
			if (timer > 15f) {
				bossText.text="頼んだよ。";
			}
			if (timer > 18f) {
				if (SubMoveMobile.EndFlag >= 2) {
					canvas.SetActive (false);
					camera.SetActive (false);
					subCnavas.SetActive (true);
					subCamera.SetActive (true);
					animator.SetBool ("Walk", true);
					animator.SetBool ("Idle", false);
					if (timer > 22f) {
						SceneManager.LoadScene ("Stage3");
					}
				} else {
					SceneManager.LoadScene ("End1");
				}
			}
		}
	}

	public void Button1(){
		//enemy.SendMessage("Recover");
		if (flag == 0) {
			audioYes.Play();
			enemy.SendMessage ("Damage");
			hitCount--;
			ChangeWord ();
			flag = 1;
			bossText.text = "わしの昔の仕事は?";
		} else {
			audioNo.Play ();
			missCount++;
			lifespan.SendMessage ("DamageFromEnemy");
		}
	}

	public void Button2(){
		//enemy.SendMessage ("Recover");
		audioNo.Play ();
		missCount++;
		lifespan.SendMessage ("DamageFromEnemy");
	}

	public void Button3(){
		if (flag == 2) {
			audioYes.Play();
			enemy.SendMessage ("Damage");
			ChangeWord3 ();
			flag = 3;
			hitCount--;
			bossText.text = "わしが探しているのは?";
		} else if (flag == 3) {
			audioYes.Play();
			enemy.SendMessage ("Damage");
			hitCount--;
		}else {
			audioNo.Play ();
			//enemy.SendMessage("Recover");
			lifespan.SendMessage ("DamageFromEnemy");
		}
	}

	public void Button4(){
		if (flag == 1) {
			audioYes.Play();
			enemy.SendMessage ("Damage");
			ChangeWord2 ();
			flag = 2;
			hitCount--;
			bossText.text = "この村には何人嘘つきがいる?";
		} else {
			//enemy.SendMessage("Recover");
			audioNo.Play ();
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


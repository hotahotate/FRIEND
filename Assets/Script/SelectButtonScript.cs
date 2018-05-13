using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class SelectButtonScript : MonoBehaviour {

	public GameObject enemy;
	public GameObject lifespan;
	public Text enemyText;
	private Animator animator;
	public GameObject robot;

	private GameObject button1;
	private GameObject button2;
	private GameObject button3;
	private GameObject button4;

	int flag=0;
	int hitCount=3;
	int missCount=0;
	float timer=0f;

	public GameObject canvas;
	public GameObject subCnavas;
	public GameObject camera;
	public GameObject subCamera;


	// Use this for initialization
	void Start () {
		button1 = GameObject.Find ("Button1");
		button2 = GameObject.Find ("Button2");
		button3 = GameObject.Find ("Button3");
		button4 = GameObject.Find ("Button4");

		subCnavas.SetActive (false);
		subCamera.SetActive (false);

		animator = robot.GetComponent<Animator>();

	}
	
	// Update is called once per frame
	void Update () {
		if (missCount == 3) {
			timer += Time.deltaTime;
			enemyText.text = "他所者に譲る物などないよ。";
			if (timer > 3f) {
				SceneManager.LoadScene ("Stage1");
			}
			} else if (hitCount == 0) {
				button1.SetActive (false);
				button2.SetActive (false);
				button3.SetActive (false);
				button4.SetActive (false);
				timer += Time.deltaTime;
				enemyText.text = "初対面だと思ったが、どうやら私の思い違いだったようだ";
				if (timer > 4f) {
					enemyText.text = "この部品を君に譲ろう";
				}
				if (timer > 6f) {
					enemyText.text = "部品1を手に入れた!";
				}
				if (timer > 8f) {
					canvas.SetActive (false);
					camera.SetActive (false);
					subCnavas.SetActive (true);
					subCamera.SetActive (true);
					animator.SetBool ("Walk", true);
					animator.SetBool ("Idle", false);
				}
				if (timer > 17f) {
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
		button1.GetComponentInChildren<Text>().text="ビッグ";
		button2.GetComponentInChildren<Text>().text="トントン";
		button3.GetComponentInChildren<Text>().text="バドーン";
		button4.GetComponentInChildren<Text>().text="バットン";
	}

	public void ChangeWord2(){
		button1.GetComponentInChildren<Text>().text="孤独な村人の事";
		button2.GetComponentInChildren<Text>().text="昔の親友の事";
		button3.GetComponentInChildren<Text>().text="息子の事";
		button4.GetComponentInChildren<Text>().text="君の事";
	}

}

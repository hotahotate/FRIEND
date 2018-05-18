using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SelectButtonScript3 : MonoBehaviour {

	public GameObject enemy;

	public GameObject button1;
	public GameObject button2;

	int flag=0;
	int hitCount=5;
	int missCount=0;

	public Text friend;
	public GameObject panel;
	public GameObject panel2;

	public Camera camera;
	//public GameObject camera2;
	public GameObject canvas;
	public GameObject subCanvas;
	public Text lastmesse;
	public GameObject startButton;
	public GameObject robot;
	public GameObject slime;
	public Text endrole;
	bool movieFlag=false;
	float timer=0f;
	Transform panelPos;

	AudioSource audioSource;

	public GameObject yes;
	public GameObject no;

	AudioSource audioYes,audioNo;


	// Use this for initialization
	void Start () {
		subCanvas.SetActive (false);
		panel2.SetActive (false);
		audioSource = camera.GetComponent<AudioSource> ();
		//camera2.SetActive (false);
		robot.SetActive (false);
		slime.SetActive (false);
		audioYes = yes.gameObject.GetComponent<AudioSource>();
		audioNo = no.gameObject.GetComponent<AudioSource> ();
		//button1 = GameObject.Find ("BattleCanvas/Button1");
		//button2 = GameObject.Find ("BattleCanvas/Button2");
	}
	
	// Update is called once per frame
	void Update () {
		if (missCount > 3) {
			timer += Time.deltaTime;
			panel.SetActive (false);
			panel2.SetActive (true);
			button1.SetActive (false);
			button2.SetActive (false);
			friend.text="やっぱり君には渡せないよ。バイバイ。";
			if (timer > 3f) {
				SceneManager.LoadScene ("End1");
			}
		}
		if (movieFlag) {
			
			timer += Time.deltaTime;
			if (timer > 0f && timer < 9f) {
				camera.transform.position += new Vector3 (0, 0, -0.05f);
			}
			if (timer > 6f&&timer<17f) {
				camera.transform.Rotate (new Vector3 (-10, 0, 0) * Time.deltaTime);
			}
			if (timer > 18f) {
				subCanvas.SetActive (true);
				startButton.SetActive (false);
				//endrole.text="FRIEND";
			}
			if (timer > 20f&&timer<38f) {
				camera.transform.Rotate(new Vector3 (0, 0, 10) * Time.deltaTime);
				/*subCanvas.SetActive (false);
				camera.transform.Rotate()
				camera2.SetActive (true);
				robot.SetActive (true);
				slime.SetActive (true);
				robot.SendMessage("GoAnim");
				camera2.transform.potision += new Vector3 (0, 0, -10);*/
			}
			if (timer > 38f) {
				subCanvas.SetActive (false);

				if (timer < 43f) {
					camera.transform.Rotate (new Vector3 (10, 0, 0) * Time.deltaTime);
				}
			}
			if(timer>40f){
				robot.SetActive (true);
				slime.SetActive (true);
				robot.SendMessage("GoAnim");
				robot.transform.position += new Vector3 (0, 0, -0.05f);
				slime.transform.position += new Vector3 (0, 0, -0.05f);
			}
			if (timer > 59f) {
				subCanvas.SetActive (true);
				startButton.SetActive (true);
				lastmesse.text="GoodEnd!";
				camera.transform.position=new Vector3(100,100,100);
				camera.clearFlags = CameraClearFlags.SolidColor;
			}
		}
	}

	public void Button1(){
		//enemy.SendMessage("Recover");
		if (flag == 1) {
			audioYes.Play();
			//Debug.Log ("1");
			enemy.SendMessage ("Damage2");
			ChangeWord2 ();
			flag = 2;
			hitCount--;
			friend.text = "そうだよね。君が僕を覚えてるわけがないんんだ。";
		} else if (flag == 2) {
			audioYes.Play();
			enemy.SendMessage ("Damage2");
			ChangeWord3 ();
			flag = 3;
			hitCount--;
			friend.text = "...そうだよ。この部品には君の過去の記憶が記されてる。";
		} else if (flag == 3) {
			audioYes.Play();
			enemy.SendMessage ("Damage2");
			ChangeWord4 ();
			flag = 4;
			hitCount--;
			friend.text = "そう思うなら、君はもっと自分の事を大切にすべきだ。";
		} else if (flag == 6) {
			audioYes.Play();
			enemy.SendMessage ("Damage2");
			ChangeWord7 ();
			flag = 7;
			hitCount--;
			panel.transform.Rotate (new Vector3 (0, 180, 0));
			friend.text = "過去を思い出すと、僕が感情を取り戻してしまうと思ったんだね。君が嘘をつき続けたのは...";
		} else if (flag == 7) {
			audioYes.Play();
			enemy.SendMessage ("Damage2");
			ChangeWord8 ();
			flag = 8;
			hitCount--;
			friend.text = "僕はきっと君と出会って、感情を知ったんだね。";
		}else if (flag == 9) {
			audioYes.Play();
			/*button1.SetActive (false);
			button2.SetActive (false);*/
			audioSource.Play ();
			canvas.SetActive (false);
			movieFlag = true;
		}  
		else {
			audioNo.Play ();
			missCount++;
		}

		/*else {
			Debug.Log ("u");
			missCount++;
		}*/
	}

	public void Button2(){
		if (flag == 0) {
			audioYes.Play();
			//Debug.Log ("2");
			enemy.SendMessage ("Damage2");
			ChangeWord ();
			flag = 1;
			hitCount--;
			panel.transform.Rotate (new Vector3 (0, 180, 0));
			friend.text = "知り合い...か。そうだね。僕と君はずっと前に会ってるよ。君は僕の事を思い出した?";
		} else if (flag == 4) {
			audioYes.Play();
			enemy.SendMessage ("Damage2");
			ChangeWord5 ();
			flag = 5;
			hitCount--;
			friend.text = "何故だと思う?";
		} else if (flag == 5) {
			audioYes.Play();
			enemy.SendMessage ("Damage2");
			button1.SetActive (false);
			button2.SetActive (false);
			friend.text = "そうだよ。君は倒れてるロボットを助けるために、自ら部品をその子に譲ったんだ。";
			Invoke ("FriendWord", 4.0f);
		} else if (flag == 8) {
			audioYes.Play();
			enemy.SendMessage ("Damage2");
			flag = 9;
			hitCount--;
			panel.transform.Rotate (new Vector3 (0, 180, 0));
			friend.text = "もしかして君は最初から";
			Invoke ("YouWord", 2.0f);
		} 
		else {
			audioNo.Play ();
			missCount++;
		}
		//enemy.SendMessage ("Recover");
		/*Debug.Log("t");
		missCount++;*/
	}

	/*public void Button3(){
		if (flag == 1) {
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
	}*/

	public void ChangeWord(){
		button1.GetComponentInChildren<Text>().text="ごめん";
		button2.GetComponentInChildren<Text>().text="思い出したよ";
		/*button3.GetComponentInChildren<Text>().text="羊羹";
		button4.GetComponentInChildren<Text>().text="カステラ";*/
	}

	public void ChangeWord2(){
		button1.GetComponentInChildren<Text>().text="君が持ってるパーツは部品99?";
		button2.GetComponentInChildren<Text>().text="君が持ってるパーツは部品67?";
		/*button3.GetComponentInChildren<Text>().text="7";
		button4.GetComponentInChildren<Text>().text="8";*/
	}

	public void ChangeWord3(){
		button1.GetComponentInChildren<Text>().text="僕の部品は僕のものだ";
		button2.GetComponentInChildren<Text>().text="返せ";
	}

	public void ChangeWord4(){
		button1.GetComponentInChildren<Text>().text="意味が分からないよ";
		button2.GetComponentInChildren<Text>().text="僕は何故部品を無くしたの?";
	}

	public void ChangeWord5(){
		button1.GetComponentInChildren<Text>().text="人間になりたくて";
		button2.GetComponentInChildren<Text>().text="誰かを助けるために部品を譲った";
	}

	public void FriendWord(){
		friend.text = "その後君は一年間眠り続け、君が助けた子はその間に結局動かなくなっちゃった。";
		Invoke ("FriendWord2", 4.0f);

	}
	public void FriendWord2(){
		friend.text = "そして僕がその事を知った時には、その子はもう解体されていた。";
		Invoke ("FriendWord3", 4.0f);

	}
	public void FriendWord3(){
		friend.text = "部品1と42。君が譲った部品もどこかへ行ってしまっていた。";
		Invoke ("FriendWord4", 4.0f);
	}

	public void FriendWord4(){
		friend.text = "初めて出会った頃は感情なんてなかった君が、あんな行動をとった。だから僕は思ったんだ。";
		Invoke ("FriendWord5", 4.0f);
	}

	public void FriendWord5(){
		friend.text = "過去を忘れれば君は出会った頃の君に戻る。そして、もうあんな事をしなくなる。";
		Invoke ("FriendWord6", 4.0f);
	}

	public void FriendWord6(){
		friend.text = "だから僕は、君から部品99を取ったんだ。...どうして君は自分が壊れてしまうのに、他人を助けようとしたんだろうね";
		button1.SetActive (true);
		button2.SetActive (true);
		ChangeWord6 ();
		flag = 6;
		hitCount--;
	}

	public void ChangeWord6(){
		button1.GetComponentInChildren<Text>().text="可哀想だったから。";
		button2.GetComponentInChildren<Text>().text="壊れたかったから。";
	}

	public void ChangeWord7(){
		button1.GetComponentInChildren<Text>().text="僕を守りたいから";
		button2.GetComponentInChildren<Text>().text="嘘をつくのが好きだから";
	}

	public void ChangeWord8(){
		button1.GetComponentInChildren<Text>().text="ごめんね";
		button2.GetComponentInChildren<Text>().text="ありがとう";
	}

	public void ChangeWord9(){
		button1.GetComponentInChildren<Text>().text="僕にとって君がどんな存在なのか。";
		button2.GetComponentInChildren<Text>().text="僕の事を";
	}

	public void YouWord(){
		panel.transform.Rotate (new Vector3 (0, 180, 0));
		friend.text = "うん。記憶は無くしても、感情は忘れなかったみたい。だから僕は思い出したいんだ。";
		ChangeWord9 ();

	}

	public void ReStartButton(){
		SceneManager.LoadScene ("Title");
	}

}

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

	public GameObject camera;
	public GameObject canvas;
	public GameObject subCanvas;
	//public GameObject robot;
	//public GameObject slime;
	public Text endrole;
	bool movieFlag=false;
	float timer=0f;


	// Use this for initialization
	void Start () {
		subCanvas.SetActive (false);
		//robot.SetActive (false);
		//slime.SetActive (false);
		//button1 = GameObject.Find ("BattleCanvas/Button1");
		//button2 = GameObject.Find ("BattleCanvas/Button2");
	}
	
	// Update is called once per frame
	void Update () {
		if (missCount > 5) {
			SceneManager.LoadScene ("GameOver");
		}
		if (movieFlag) {
			timer += Time.deltaTime;
			if (timer > 0f && timer < 9f) {
				camera.transform.position += new Vector3 (0, 0, -0.1f);
			}
			if (timer > 3f&&timer<14f) {
				camera.transform.Rotate (new Vector3 (-10, 0, 0) * Time.deltaTime);
			}
			if (timer > 15f) {
				subCanvas.SetActive (true);
				endrole.text="FRIEND";
			}
			if (timer > 18f&&timer<29f) {
				camera.transform.Rotate (new Vector3 (-10, 0, 0) * Time.deltaTime);
			}
			if (timer > 29f) {
				/*robot.SetActive (true);
				slime.SetActive (true);
				robot.transform.position += new Vector3 ();
				slime.transform.position += new Vector3 ();*/
			}
		}
	}

	public void Button1(){
		//enemy.SendMessage("Recover");
		if (flag == 1) {
			Debug.Log ("1");
			enemy.SendMessage ("Damage2");
			ChangeWord2 ();
			flag = 2;
			hitCount--;
			friend.text = "そうだよね。君が僕を覚えてるわけがないんんだ。";
		} else if (flag == 2) {
			enemy.SendMessage ("Damage2");
			ChangeWord3 ();
			flag = 3;
			hitCount--;
			friend.text = "...そうだよ。これを付ければ、君は全てを思い出してしまう。";
		} else if (flag == 3) {
			enemy.SendMessage ("Damage2");
			ChangeWord4 ();
			flag = 4;
			hitCount--;
			friend.text = "そう思うなら、君はもっと自分の事を大切にすべきだ。";
		} else if (flag == 6) {
			enemy.SendMessage ("Damage2");
			ChangeWord7 ();
			flag = 7;
			hitCount--;
			panel.transform.Rotate (new Vector3 (0, 180, 0));
			friend.text = "メモリをつけると、僕が感情を取り戻してしまうと思ったんだね。君が嘘をつき続けたのは...";
		} else if (flag == 7) {
			enemy.SendMessage ("Damage2");
			ChangeWord8 ();
			flag = 8;
			hitCount--;
			friend.text = "僕はきっと君と出会って、感情を知ったんだね。";
		}else if (flag == 9) {
			/*button1.SetActive (false);
			button2.SetActive (false);*/
			canvas.SetActive (false);
			movieFlag = true;
		}  
		else {
			missCount++;
		}

		/*else {
			Debug.Log ("u");
			missCount++;
		}*/
	}

	public void Button2(){
		if (flag == 0) {
			Debug.Log ("2");
			enemy.SendMessage ("Damage2");
			ChangeWord ();
			flag = 1;
			hitCount--;
			panel.transform.Rotate (new Vector3 (0, 180, 0));
			friend.text = "知り合い...か。そうだね。僕と君はずっと前に会ってるよ。君は僕の事を思い出した?";
		} else if (flag == 4) {
			enemy.SendMessage ("Damage2");
			ChangeWord5 ();
			flag = 5;
			hitCount--;
			friend.text = "何故だと思う?";
		} else if (flag == 5) {
			enemy.SendMessage ("Damage2");
			friend.text = "そうだよ。君は倒れてる機械を助けるために、自ら部品をその子に譲ったんだ。";
			Invoke ("FriendWord", 5.0f);
		} else if (flag == 8) {
			enemy.SendMessage ("Damage2");
			flag = 9;
			hitCount--;
			panel.transform.Rotate (new Vector3 (0, 180, 0));
			friend.text = "もしかして君は最初から";
			Invoke ("YouWord", 5.0f);
		} 
		else {
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
		button1.GetComponentInChildren<Text>().text="君が持ってる部品はメモリ?";
		button2.GetComponentInChildren<Text>().text="君が持ってる部品は何?";
		/*button3.GetComponentInChildren<Text>().text="7";
		button4.GetComponentInChildren<Text>().text="8";*/
	}

	public void ChangeWord3(){
		button1.GetComponentInChildren<Text>().text="僕の部品は僕のものだ";
		button2.GetComponentInChildren<Text>().text="返せ";
	}

	public void ChangeWord4(){
		button1.GetComponentInChildren<Text>().text="どういう意味?";
		button2.GetComponentInChildren<Text>().text="僕は何故部品を無くしたの?";
	}

	public void ChangeWord5(){
		button1.GetComponentInChildren<Text>().text="人間になりたくて";
		button2.GetComponentInChildren<Text>().text="誰かを助けるために部品を譲った";
	}

	public void FriendWord(){
		friend.text = "ネジと言語処理機能、そしてメモリ。出会った頃は感情なんてなかった君が、そんな行動をとった。";
		ChangeWord6 ();
		flag = 6;
		hitCount--;
	}

	public void ChangeWord6(){
		button1.GetComponentInChildren<Text>().text="可哀想だと思ったんだと思う。";
		button2.GetComponentInChildren<Text>().text="哀れだと思ったんだと思う。";
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

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class TextController : MonoBehaviour {

	//シナリオを格納
	private string[] scenarios2;
	//uiTextへの参照を保つ
	private Text uiText;
	//public Text message;

	//現在の行番号
	int currentLine;

	//add
	public Text message;
	int flag=0;
	//fin

	public GameObject panel;

	public static bool bossFlag = false;

	// Use this for initialization
	public void StartText (string[] scenarios/*Text message*/) {
		//add
		flag=1;
		scenarios2=scenarios;
		//fin
		currentLine = 0;
		uiText = message;
		panel.SetActive (true);
		uiText.gameObject.SetActive (true);
		//GoButton=GameObject.Find ("Canvas/LeftButton/Go").GetComponent<Button> ();
		//GoButton.interactable = false;
		SubMoveMobile.GoFlag=false;
		TextUpdate ();

	}

	public void Click(){
		if (flag == 1) {
			//現在の行番号がラストまで行ってない状態でAボタンを押すとテキストを更新する
			if (currentLine < scenarios2.Length) {
				
				TextUpdate ();
				//Debug.Log ("uhh");
			} else {
					//問題点:最後の行の文字列が表示されずに終了する
					uiText.gameObject.SetActive (false);
					panel.SetActive (false);
					flag = 0;
				//GoButton.interactable = true;
				SubMoveMobile.GoFlag=true;
				if (SceneManager.GetActiveScene ().name == "Stage3") {
					bossFlag = true;
				}
			}
		}

	}

	//PCで試すよう。Iphoneに操作切り替えるときはコメントアウトする
	//ここから
	// Update is called once per frame
	void Update () {

		if (flag == 1) {
			//現在の行番号がラストまで行ってない状態でMボタンを押すとテキストを更新する
			if (currentLine < scenarios2.Length && Input.GetKeyDown (KeyCode.M)) {
				TextUpdate ();
			} else {
				if (Input.GetKeyDown (KeyCode.M)) {
					//問題点:最後の行の文字列が表示されずに終了する
					uiText.gameObject.SetActive (false);
					panel.SetActive (false);
					flag = 0;
				}
			}
		}
	}

	//ここまで

	void TextUpdate(){
		//現在の行番号をuiTextに流し込み、現在の行番号を一つ追加する
		uiText.text = scenarios2 [currentLine];
		currentLine++;
	}


}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHP : MonoBehaviour {

	//public static int life = 10;
	public static int life;
	public Text lifeText;
	public float timer=0;
	//0：探索モード,1:交渉モード
	//public static int flag=0;

	//add
	//string key="SaveLife";

	IEnumerator coroutineMethod;

	// Use this for initialization
	void Start () {
		//life = PlayerPrefs.GetInt (key, 10);
		/*if (flag == 0) {
			InvokeRepeating ("DamageFromEnemy", 5f, 50f);
		}*/
		coroutineMethod = DamageFromTime ();
		StartCoroutine (coroutineMethod);
	}
	
	// Update is called once per frame
	void Update () {
		lifeText.text = "寿命: " + life.ToString ();
	}

	public void DamageFromEnemy(){
		life--;
		//lifeText.text = "寿命: " + life.ToString ();
	}

	/*public void DamageFromTime(){
			life--;
			//lifeText.text = "寿命: " + life.ToString ();
		}*/

	public void PoseButtonCoroutine(){
		StopCoroutine (coroutineMethod);
	}

	public void ReturnButtonCoroutine(){
		StartCoroutine (coroutineMethod);
	}

	public IEnumerator DamageFromTime(){
		while (true) {
			yield return new WaitForSeconds (3f);
			life--;
			Debug.Log (life);
		}
	}
		
	}


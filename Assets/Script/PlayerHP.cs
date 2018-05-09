using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerHP : MonoBehaviour {

	//public static int life = 10;
	public static int life;
	public Text lifeText;
	public float timer=0;
	//0：探索モード,1:交渉モード
	//public static int flag=0;


	IEnumerator coroutineMethod;

	// Use this for initialization
	void Start () {
		coroutineMethod = DamageFromTime ();
		StartCoroutine (coroutineMethod);
	}
	
	// Update is called once per frame
	void Update () {
		lifeText.text = "寿命: " + life.ToString ();
		if (life == 0) {
			//SceneManager.LoadScene("GameOver");
		}
	}

	public void DamageFromEnemy(){
		life--;
	}
		

	public void PoseButtonCoroutine(){
		StopCoroutine (coroutineMethod);
	}

	public void ReturnButtonCoroutine(){
		StartCoroutine (coroutineMethod);
	}

	public IEnumerator DamageFromTime(){
		while (true) {
			yield return new WaitForSeconds (50f);
			life--;
			//Debug.Log (life);
		}
	}
		
	}


using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHP : MonoBehaviour {

	public static int life = 10;
	public Text lifeText;
	public float timer=0;
	//0：探索モード,1:交渉モード
	public int flag=0;

	// Use this for initialization
	void Start () {
		lifeText.text = "寿命: " + life.ToString ();
		if (flag == 0) {
			InvokeRepeating ("DamageFromEnemy", 5f, 50f);
		}
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void DamageFromEnemy(){
		life--;
		lifeText.text = "寿命: " + life.ToString ();
	}

	public void DamageFromTime(){
			life--;
			lifeText.text = "寿命: " + life.ToString ();
		}
	}


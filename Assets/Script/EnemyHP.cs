using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyHP : MonoBehaviour {

	public Slider slider;
	float enemyHP;


	// Use this for initialization
	void Start () {
		enemyHP = slider.maxValue;
	}
	
	// Update is called once per frame
	void Update () {
		slider.value = enemyHP;
	}

	void Damage(){
		enemyHP -= 0.3f;
		if (enemyHP <= slider.minValue) {
			//Destroy (this.gameObject);
		}
	}

	void Recover(){
		if (enemyHP < slider.maxValue) {
			enemyHP += 0.3f;		
		}
	}

	void Damage2(){
		enemyHP -= 0.1f;
	}
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerScript : MonoBehaviour {

	//Rigidbody rb;
	//移動スピード
	public float speed = 2f;
	//ジャンプ力
	public float thrust = 100;
	//Animatorを入れる変数
	private Animator animator;
	//Planeに触れているか判定するため
	bool ground;

	void Start()
	{
		//rb = GetComponent<Rigidbody>();
		//UnityちゃんのAnimatorにアクセスする
		animator = GetComponent<Animator>();
	}

	void Update()
	{






		// Update is called once per frame
		if (Input.GetAxis ("Vertical") == 0 && Input.GetAxis ("Horizontal") == 0) {
			animator.SetBool ("Walk", false);
			animator.SetBool ("Idle", true);
		} else {
			if (Input.GetKey ("up")) {
				transform.position += transform.forward * 0.01f;
				animator.SetBool ("Idle", false);
				animator.SetBool ("Walk", true);
			} 
			if (Input.GetKey ("right")) {
				transform.Rotate (0, 10, 0);
			}
			if (Input.GetKey ("left")) {
				transform.Rotate (0, -10, 0);
			}
		}

	}

	void OnTriggerEnter(Collider other){
		if (other.gameObject.tag == "boss1") {
			SceneManager.LoadScene ("Battle1");
		}
		if (other.gameObject.tag == "boss2") {
			SceneManager.LoadScene ("Battle2");
		}
	}
}


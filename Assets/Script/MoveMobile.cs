using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;
using UnityEngine.AI;

public class MoveMobile : MonoBehaviour {

	//NavMeshAgent agent = null;
	//public GameObject player;
	//float timer=0;
	float speed=5.0f;
	bool push=false;
	bool pushRight=false;
	bool pushLeft=false;
	private Animator animator;
	//int itemFlag=0;

	GameObject poseController;

	public static bool GoFlag=true;

	public static int EndFlag=0;

	void Start () {
		//agent = GetComponent<NavMeshAgent> ();
		animator = GetComponent<Animator>();

		poseController=GameObject.Find("PoseController");
	}

	public void PushDown(){
		push = true;
		//pushRight = true;
	}

	public void PushDownRight(){
		pushRight = true;
	}

	public void PushDownLeft(){
		pushLeft = true;
	}

	public void PushUp(){
		push = false;
		//pushRight = false;
	}

	public void PushUpRight(){
		pushRight = false;
	}

	public void PushUpLeft(){
		pushLeft = false;
	}

	// Update is called once per frame
	void Update () {
		if (push) {
			GoButton ();
		}
		else {
			animator.SetBool ("Walk", false);
			animator.SetBool ("Idle", true);
		}
		if (pushRight) {
			Right ();
		}
		if (pushLeft) {
			Left ();
		}

		// 入力を取得
		/*var v1 = CrossPlatformInputManager.GetAxis ("Vertical");
		var h1 = CrossPlatformInputManager.GetAxis ("Horizontal");*/

		var v2 = CrossPlatformInputManager.GetAxis ("Vertical2");
		var h2 = CrossPlatformInputManager.GetAxis ("Horizontal2");

		// スティックが倒れていれば、移動
		/*if (h1 != 0 || v1 != 0) {
			var direction = new Vector3 (h1, 0, v1);
			agent.Move (direction * Time.deltaTime);
		}*/
		// スティックが倒れていれば、倒れている方向を向く
		if( h2 != 0 || v2 != 0){
			var direction = new Vector3 (h2, 0, v2);
			//transform.localRotation = Quaternion.LookRotation (direction);
			Quaternion targetRotation=Quaternion.LookRotation (direction);
			transform.rotation=Quaternion.Slerp(transform.rotation,targetRotation,Time.deltaTime);
		}
	}

	public void GoButton(){
		if (GoFlag) {
			animator.SetBool ("Idle", false);
			animator.SetBool ("Walk", true);
			transform.position += transform.forward * speed * Time.deltaTime;
		}
	}

	void OnTriggerEnter(Collider other){
		if (other.gameObject.name == "Diary1") {
			EndFlag++;
			Destroy (other.gameObject);
			poseController.SendMessage ("Flag", 1);
		}

		if (other.gameObject.name == "Diary2") {
			EndFlag++;
			Destroy (other.gameObject);
			poseController.SendMessage ("Flag", 2);
		}
	}


	//ボタン右左
	public void Right(){
		transform.Rotate (0, 5, 0);
	}

	public void Left(){
		transform.Rotate (0, -5, 0);
	}
}
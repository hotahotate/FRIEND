using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnim : MonoBehaviour {

	private Animator animator;

	int count=0;

	// Use this for initialization
	void Start () {
		animator = GetComponent<Animator> ();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void GoAnim(){
		count++;
		animator.SetBool ("Walk", true);
		animator.SetBool ("Idle", false);
		Debug.Log ("count.ToString()");
	}

	void IdleAnim(){
		animator.SetBool ("Idle", true);
		animator.SetBool ("Walk", false);
	}
}

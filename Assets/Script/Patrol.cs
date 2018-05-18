using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Patrol : MonoBehaviour {

	public Transform[] points;
	private int destPoint=0;
	private NavMeshAgent agent;

	//add
	public Transform target;

	// Use this for initialization
	void Start () {
		agent = GetComponent<NavMeshAgent> ();

		agent.autoBraking = false;
		GoToNextPoint ();

	}

	void GoToNextPoint(){
		if (points.Length == 0)
			return;

		agent.destination = points [destPoint].position;
		destPoint = (destPoint + 1) % points.Length;
	}

	void Update(){
		if (agent.remainingDistance < 0.5f)
			GoToNextPoint();
	}

	void OnTriggerEnter(Collider other){
		if (other.gameObject.tag == "player") {
			agent.Stop();
			//Debug.Log ("Robot");
			transform.root.LookAt (target);
		}
	}

	void OnTriggerExit(Collider other){
		if (other.gameObject.tag == "player") {
			//Debug.Log ("Byby");
			agent.Resume ();
		}
	}
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MovieController : MonoBehaviour {
	

	float timer=0;
	public GameObject friend;
	public GameObject friend2;
	public GameObject robot;
	public GameObject robot2;
	public GameObject camera2set;
	public Text title;
	private Animator animator;
	AudioSource audioSource;
	public AudioClip blackSound;

	public GameObject camera2;
	public GameObject camera3;
	public GameObject camera4;


	bool flag=false;
	//float angle=0;
	public float minAngle=0.0f;
	public float maxAngle=90.0f;

	// Use this for initialization
	void Start () {
		animator = friend.GetComponent<Animator>();
		audioSource = camera4.AddComponent<AudioSource> ();
		audioSource.clip = blackSound;
		robot2.SetActive (false);
		camera2.SetActive (false);
		camera3.SetActive (false);
		camera4.SetActive (false);
		friend2.SetActive (false);
	}
	
	// Update is called once per frame
	void Update () {
		timer += Time.deltaTime;
		if (Input.GetKeyDown ("space")) {
			Application.Quit ();
		}
		/*if (flag) {
			float angle = Mathf.LerpAngle (minAngle, maxAngle, 1f);
			camera3.transform.eulerAngles = new Vector3 (angle, 0, 0);
		}*/

		if (timer > 0.0f) {
			friend.transform.position += new Vector3 (0, 0, 0.03f);
		}
		if (timer > 7f) {
			audioSource.Play ();

			robot.SetActive (false);
			robot2.SetActive (true);
			friend.SetActive (false);
			friend2.SetActive (true);

			camera4.SetActive (true);
		}
		if (timer > 10f) {
			/*robot.SetActive (false);
			robot2.SetActive (true);
			friend.SetActive (false);
			friend2.SetActive (true);*/
			camera4.SetActive (false);
			camera2.SetActive (true);
			camera2set.transform.position += new Vector3 (0, 0, -0.01f);
		}
		if (timer > 14f) {
			camera2.SetActive (false);
			camera3.SetActive (true);
			//flag = true;
			if (14f < timer && timer < 18f) {
				camera3.transform.Rotate (new Vector3 (-10, 0, 0) * Time.deltaTime);
			}
		}
		if (timer > 19f) {
			title.text="FRIEND";
		}
	}
}

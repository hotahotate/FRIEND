using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraScript : MonoBehaviour {

		public GameObject target;

		void Update () {
			transform.position = target.transform.position + new Vector3 (0, 1.0f, -4.0f);
		}
	}


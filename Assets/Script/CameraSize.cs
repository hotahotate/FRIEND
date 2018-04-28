using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraSize : MonoBehaviour {

	void Awake(){
		float developAspect = 1334.0f / 750.0f;
		float deviceAspect = (float)Screen.width / (float)Screen.height;

		float scale = deviceAspect / developAspect;

		Camera mainCamera = Camera.main;

		float deviceSize = mainCamera.orthographicSize;
		float deviceScale = 1.0f / scale;
		mainCamera.orthographicSize = deviceSize * deviceScale;
	}
		
}

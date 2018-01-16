using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ErrorHandler : MonoBehaviour {
	public GameObject ErrorPanel;
	public GameObject KeypadPanel;
	private Boolean gazedAt;
	private float gazeTime = 1.5f;
	private float timer = 0f;
	public Text code;

	void Update () {
		if (gazedAt) {
			timer += Time.deltaTime;

		}
		if (timer >=1.5f) {
			ErrorPanel.SetActive (false);
			KeypadPanel.SetActive (true);
		
			//code.text = "";
		}

	}
	public void Resetinator(){
		timer = 0f;
	}

	public void PointerEnter(){
		gazedAt=true;
		//	Debug.Log ("Pointer Enter");
	}

	public void PointerExit(){
		gazedAt=false;
		//Debug.Log ("Pointer Exit");
	}

}

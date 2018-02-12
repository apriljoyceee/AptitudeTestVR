using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.SceneManagement;

public class backtomain : MonoBehaviour {

	// Use this for initialization
	private Boolean gazedAt;
	private float timer = 0f;
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (gazedAt) {
			timer += Time.deltaTime;

		}
		if (timer >= 1.5f) {
			SceneManager.LoadScene ("KeypadScene");
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

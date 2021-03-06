﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ReturnMenu : MonoBehaviour {

	private float timer;
	private float gazeTime =2.5f;
	private bool gazedAt;

	// Use this for initialization
	void Start () {
		
	}

	void Update () {
		if (gazedAt) {
			timer += Time.deltaTime;

			if (timer >= gazeTime) {
				SceneManager.LoadScene ("ScoreScene");
				gazedAt=false;
			}
		}

	}
	public void PointerEnter(){
		//Debug.Log ("Pointer Enter");
		gazedAt=true;
	}
	public void PointerExit(){
		//Debug.Log ("Pointer Enter");
		gazedAt=false;
	}
}

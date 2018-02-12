using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class sorttest : MonoBehaviour {
	public string[] categoryscores;

	// Use this for initialization
	void Start () {
		categoryscores = new string[5];
		categoryscores [0] = "1";
		categoryscores [1] = "6";
		categoryscores [2] = "11";
		categoryscores [3] = "4";
		categoryscores [4] = "5";
		Array.Sort (categoryscores);

		foreach (string value in categoryscores) {
			Debug.Log (value);
		}


	}
	
	// Update is called once per frame
	void Update () {
		
	}
}

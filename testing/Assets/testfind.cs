using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class testfind : MonoBehaviour {
	public GameObject bboard;
	public static string nameofobject;

	void Awake(){
		bboard.GetComponent<Renderer> ().enabled = false;
		GameObject.DontDestroyOnLoad (bboard);
	}
	void Start(){
		
		nameofobject = bboard.transform.name;
	}
}
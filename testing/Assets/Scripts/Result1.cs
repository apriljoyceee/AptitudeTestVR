using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Result1 : MonoBehaviour {
	public Text category1Text;
	public Text category2Text;
	// Use this for initialization
	void Start () {
		category1Text.text = "Language Development: " + GameController.category1.ToString();

	}
	
	// Update is called once per frame
	void Update () {
		
	}
}

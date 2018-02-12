using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class displayresults : MonoBehaviour {
	
	public Text totalscore;
	// Use this for initialization
	void Start () {

		totalscore.text= "" + GameController.playerScore.ToString()+ "/30";
	}
	// Update is called once per frame
	void Update () {
	}
}

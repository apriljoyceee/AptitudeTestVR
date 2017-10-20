using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class timercnt : MonoBehaviour {
	public float timeLeft = 300f;
	int minute;
	int second;
	public Text text;
	void start(){
	}

	void update(){
		timeLeft -= Time.deltaTime;
		minute = Mathf.FloorToInt (timeLeft / 60f);
		second = Mathf.FloorToInt (timeLeft - minute * 60);
		text.text = minute.ToString () + ":" + second.ToString ();
	}

}

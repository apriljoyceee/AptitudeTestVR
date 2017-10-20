using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class timer : MonoBehaviour {

    public float timeLeft = 300f;
	int minute;
	int second;
	public Text text;
	void start(){
		
	}
     
     void Update() {
		timeLeft -= Time.deltaTime;
		minute = Mathf.FloorToInt (timeLeft / 60f);
		second = Mathf.FloorToInt (timeLeft - minute * 60);
		text.text = "Time " + minute.ToString () + ":" + second.ToString ();
     }
 
}

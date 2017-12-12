using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class GazeTimer : MonoBehaviour {
	public float MyTime = 0f;
	public Transform RadialProgress;
	// Use this for initialization
	void Start () {
		RadialProgress.GetComponent<Image> ().fillAmount = MyTime;
	}
	
	// Update is called once per frame
	void Update () {
		MyTime += Time.deltaTime;
		RadialProgress.GetComponent<Image> ().fillAmount = MyTime/1.5f;
		if(MyTime >=1.5f){
		}
	}

	public void Resetinator(){
		MyTime = 0f;
		RadialProgress.GetComponent<Image> ().fillAmount = MyTime;
	}
}

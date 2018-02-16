using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WrongScript : MonoBehaviour {
	private float gazeTime = 1.5f;
	private float timer = 0f;
	private bool gazedAt;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (gazedAt) {
			timer += Time.deltaTime;
		}
		if (timer >=1.5f) {

			//GameController;
		}
	}
	public void PointerEnter(){

		gazedAt=true;
	}
	public void Resetinator(){
		timer = 0f;
	}
	public void PointerExit(){

		gazedAt=false;
	}
}

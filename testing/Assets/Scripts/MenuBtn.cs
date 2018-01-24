using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MenuBtn : MonoBehaviour {

	private float timer;
	private float gazeTime =2.5f;
	private bool gazedAt;


	// Use this for initialization
	void Start () {
		
	}
	public void Setup(AnswerData data){
		
	}
	void Update () {
		if (gazedAt) {
			timer += Time.deltaTime;

			if (timer >= gazeTime) {
				SceneManager.LoadScene ("TestScene");
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

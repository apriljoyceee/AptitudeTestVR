using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Choice1Try : MonoBehaviour {

	private float timerr;
	private float gazeTimee =1.5f;
	private bool gazedAtt;
	// Use this for initialization
	void Start () {

	}

	// Update is called once per frame
	void Update () {
		
		if (gazedAtt) {
			timerr += Time.deltaTime;
			Debug.Log ("TRY");
			if (timerr >= gazeTimee) {
				
				SceneManager.LoadScene("Aptitude Scene 2");
			}
		}

	}

	public void PointerEnter(){
		Debug.Log ("Pointer Enter");
		gazedAtt=true;
	}
	public void PointerExit(){
		//Debug.Log ("Pointer Enter");
		gazedAtt=false;
	}

}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class QuitScript : MonoBehaviour {
	private float timer;
	private float gazeTime =2.5f;
	private bool gazedAt;

	void Update () {
		if (gazedAt) {
			timer += Time.deltaTime;

			if (timer >= gazeTime) {
				Application.Quit();
			}
		}
	}

	public void PointerEnter(){
		Debug.Log ("QUIT");
		gazedAt=true;
	}

	public void PointerExit(){
		//Debug.Log ("Pointer Enter");
		gazedAt=false;
	}

}

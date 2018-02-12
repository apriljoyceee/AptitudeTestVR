using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class StartCcript : MonoBehaviour {
	private float gazeTime = 1.5f;
	private float timer = 0f;
	private bool gazedAt;
	public AudioSource beepaudio;
	// Use this for initialization\
	void Start () {
		//Debug.Log ("NAME OF GAME OBJECT IS: " + testfind.nameofobject);
		//Debug.Log ("NAME OF GAME OBJECT IS: " + testfind.nameofobject);

		//if (GameObject.Find (testfind.nameofobject) != null) {
		//	Debug.Log ("IT EXISTS");
		//}
	}
	
	// Update is called once per frame
	void Update () {
		if (gazedAt) {
			timer += Time.deltaTime;
		}
		if (timer >=1.5f) {
			beepaudio.Play();
			SceneManager.LoadScene("Game");
		}

	}

	public void Resetinator(){
		timer = 0f;
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

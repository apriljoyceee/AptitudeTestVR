using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartCcript : MonoBehaviour {

	private float gazeTime = 1.5f;
	private float timer = 0f;
	private bool gazedAt;
	public AudioSource beepaudio;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (gazedAt) {
			timer += Time.deltaTime;
		}
		if (timer >=1.5f) {
			beepaudio.Play();
			SceneManager.LoadScene("Aptitude Scene");
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

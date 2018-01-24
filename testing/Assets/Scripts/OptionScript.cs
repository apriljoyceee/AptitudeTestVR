using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class OptionScript : MonoBehaviour {
	private float timer;
	private float gazeTime = 1.5f;
	private bool gazedAt;
	public AudioSource beepaudio;
	//public GameObject SettingsPanel;
	// Use this for initialization
	void Start () {
		//SettingsPanel.transform.localScale = new Vector3(0, 0, 0);
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void Resetinator(){
		timer = 0f;
	}

	public void PointerEnter(){
		//Debug.Log ("Pointer Enter");
		gazedAt=true;
		beepaudio.Play();
	}

	public void PointerExit(){
		//Debug.Log ("Pointer Enter");
		gazedAt=false;
	}

}

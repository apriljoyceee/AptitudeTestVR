using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MedVolumeScript : MonoBehaviour {

	private float gazeTime = 1.5f;
	private float timer = 0f;
	private bool gazedAt;

	public Toggle medvol_Toggle;
	public Slider VolumeSlider;
	public AudioSource beepaudio;
	//public Text m_Text;
	// Use this for initialization
	// Update is called once per frame

	void Start()
	{

	}
	void Update(){
		if (gazedAt) {
			timer += Time.deltaTime;
		}
		if (timer >=1.5f) {
			if (medvol_Toggle.isOn == false) {
				medvol_Toggle.isOn = true;
				Debug.Log ("MED VOLUME");
				beepaudio.Play();
				VolumeSlider.value = -10f;
			}
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

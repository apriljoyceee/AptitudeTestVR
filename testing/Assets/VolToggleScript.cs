using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class VolToggleScript : MonoBehaviour {

	private float gazeTime = 1.5f;
	private float timer = 0f;
	private bool gazedAt;

	public Toggle highvol_Toggle;
	public Toggle medvol_Toggle;
	public Toggle lowvol_Toggle;

	public Slider VolumeSlider;
	//public Text m_Text;
	// Use this for initialization
	// Update is called once per frame

	void Start()
	{

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

	//Output the new state of the Toggle into Text
	public void highvol_ToggleChanged(bool newValue)
	{
		if (gazedAt == true && newValue ==true){
			Debug.Log ("HIGH VOLUME");
			VolumeSlider.value = 1f;
		}
	}

	public void medvol_ToggleChanged(bool newValue)
	{
		if (gazedAt == true && newValue ==true){
			Debug.Log ("MEDIUM VOLUME");
			VolumeSlider.value = 0.50f;
		}
	}

	public void lowvol_ToggleChanged(bool newValue)
	{
		if (gazedAt == true && newValue ==true){
			Debug.Log ("LOW VOLUME");
			VolumeSlider.value = 0.20f;
		}
	}
}

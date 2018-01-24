using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class VolToggleScript : MonoBehaviour {
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
	//Output the new state of the Toggle into Text
	public void highvol_ToggleChanged(bool newValue)
	{
		if (newValue ==true){
			Debug.Log ("HIGH VOLUME");
			VolumeSlider.value = 1f;
		}
	}

	public void medvol_ToggleChanged(bool newValue)
	{
		if (newValue ==true){
			Debug.Log ("MEDIUM VOLUME");
			VolumeSlider.value = 0.50f;
		}
	}

	public void lowvol_ToggleChanged(bool newValue)
	{
		if (newValue ==true){
			Debug.Log ("LOW VOLUME");
			VolumeSlider.value = 0.20f;
		}
	}
		

	void Update () {

	}
}

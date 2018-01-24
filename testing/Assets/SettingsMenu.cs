using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class SettingsMenu : MonoBehaviour {

	public AudioMixer audioMixerL;
	public void SetVolume (float volume){
		audioMixerL.SetFloat ("volume", volume);
	}
}

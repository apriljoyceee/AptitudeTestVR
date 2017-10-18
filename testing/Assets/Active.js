#pragma strict

import System.Collections;
import UnityEngine;
import UnityEngine.UI;
import UnityEngine.SceneManagement;

var button : UI.Image;
var code : UI.Text;
var Hover : Color;
var Original : Color;
private var timer : float;
private var gazeTime : float = 1.5f;
private var gazedAt : boolean;
public var beepaudio : AudioSource;

function Start () {
	//code = GetComponent(Text);

}


function Update () {
	if (gazedAt) {
			timer += Time.deltaTime;

				//if (timer >= gazeTime) {
				//	SceneManager.LoadScene("Scene1");
			//	}
			//button.Color=Hover;
			if (timer >= gazeTime) {
						if(code.text=="12"){
							beepaudio.volume = 0.5;
							beepaudio.pitch = 1;
							beepaudio.Play();
							//DATABASE STUDENT OK
							SceneManager.LoadScene("TestScene");
						}
						else{
							code.text = "";
							KeypadSystem_.maxNumbers = 0;
							beepaudio.volume = 0.3;
							beepaudio.pitch = 0.8;
							beepaudio.Play();
							timer=0f;
							Debug.Log ("WALA");
						}
					}
				}
}

public function PointerEnter(){
		gazedAt=true;
		Debug.Log ("Pointer Enter");
		button.color = Hover;
		beepaudio.volume = 0.3;
		beepaudio.pitch = 1;
		beepaudio.Play();
}

public function PointerExit(){
		gazedAt=false;
		Debug.Log ("Pointer Exit");
		beepaudio.Stop();
		button.color = Original;
}


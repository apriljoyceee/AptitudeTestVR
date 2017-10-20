#pragma strict

import System.Collections;
import UnityEngine;
import UnityEngine.UI;
var button : UI.Image;
var code : UI.Text;

var Hover : Color;
var Original : Color;
var addNumber : String;
private var timer : float;
private var gazeTime : float = 1.5f;
private var gazedAt : boolean;

public var beepaudio : AudioSource;

function Start () {
	//code = GetComponent(Text);
	//hoverAudio = GetComponent.<AudioSource>();
	//pressAudio = GetComponent.<AudioSource>();
}


function Update () {
	if (gazedAt) {
			timer += Time.deltaTime;

				//if (timer >= gazeTime) {
				//	SceneManager.LoadScene("Scene1");
			//	}
			//button.Color=Hover;
			if (timer >= gazeTime) {
					if(KeypadSystem_.maxNumbers < 2){
						code.text += addNumber;
						KeypadSystem_.maxNumbers ++;
						beepaudio.volume = 0.3;
						beepaudio.pitch = 0.85;
						beepaudio.Play();
						Debug.Log ("1 is clicked");
						timer=0f;

					}
				}
			}
}

public function PointerEnter(){
		gazedAt=true;
		Debug.Log ("Pointer Enter");
		button.color = Hover;
		beepaudio.volume = 0.3;
		beepaudio.pitch = 0.1;
		beepaudio.Play();
}

public function PointerExit(){
		gazedAt=false;
		Debug.Log ("Pointer Exit");
		beepaudio.Stop();
		button.color = Original;
}


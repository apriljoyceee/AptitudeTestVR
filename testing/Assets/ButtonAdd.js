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
private var gazeTime : float = 2.5f;
private var gazedAt : boolean;

function Start () {
	//code = GetComponent(Text);

}


function Update () {
/*if (gazedAt) {
		timer += Time.deltaTime;

			//if (timer >= gazeTime) {
			//	SceneManager.LoadScene("Scene1");
		//	}
		//button.Color=Hover;
		if (timer == gazeTime) {
			if(KeypadSystem_.maxNumbers < 2){
				code.text += addNumber;
				KeypadSystem_.maxNumbers ++;
				Debug.Log ("1 is clicked");
			}
			}
		}*/
}

public function PointerEnter(){
		gazedAt=true;
		Debug.Log ("Pointer Enter");

		button.color = Hover;
}

public function PointerExit(){
		gazedAt=false;
		Debug.Log ("Pointer Exit");

		button.color = Original;
}
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AnswerButton : MonoBehaviour {

	private float timer;
	private float gazeTime =2.5f;
	private bool gazedAt;
	public Text answerText;
	private GameController gameController;
	private AnswerData answerData;

	// Use this for initialization
	void Start () {
		gameController = FindObjectOfType<GameController> ();
	}
	public void Setup(AnswerData data){
		answerData = data;
		answerText.text = answerData.answerText;
	}
	void Update () {
		if (gazedAt) {
			timer += Time.deltaTime;

			if (timer >= gazeTime) {
				gameController.AnswerButtonClicked (answerData.isCorrect);
				gazedAt=false;
			}
		}

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

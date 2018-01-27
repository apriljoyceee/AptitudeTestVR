using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Category : MonoBehaviour {

	public Text category1Text;
	public Text category2Text;
	public Text category3Text;
	public Text category4Text;
	public Text category5Text;
	public Text category6Text;
	public Text category7Text;
	public Text category8Text;
	public Text category9Text;

	public Text totalScoreText;

	public Text most1Text;
	public Text most2Text;
	public Text most3Text;
	public Text most4Text;
	public Text most5Text;

	public Text least1Text;
	public Text least2Text;
	public Text least3Text;
	public Text least4Text;
	public Text least5Text;
	// Use this for initialization
	void Start () {
		category1Text.text = GameController.category1.ToString ();
		category2Text.text = GameController.category2.ToString ();
		category3Text.text = GameController.category3.ToString ();
		category4Text.text = GameController.category4.ToString ();
		category5Text.text = GameController.category5.ToString ();
		category6Text.text = GameController.category6.ToString ();
		category7Text.text = GameController.category7.ToString ();
		category8Text.text = GameController.category8.ToString ();
		category9Text.text = GameController.category9.ToString ();
	}

	public void mostLearned(){
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}

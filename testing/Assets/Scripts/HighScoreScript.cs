using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HighScoreScript : MonoBehaviour {

	public GameObject id;
	public GameObject scoreName;
	public GameObject choice1;
	public GameObject choice2;

	public void SetScore(string name, string choice1, string choice2, string id)
	{
		this.scoreName.GetComponent<Text> ().text = name;
		this.choice1.GetComponent<Text> ().text = choice1;
		this.choice2.GetComponent<Text> ().text = choice2;
		this.id.GetComponent<Text> ().text = id;
	}
		
}
